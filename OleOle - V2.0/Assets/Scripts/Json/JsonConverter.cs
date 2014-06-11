using UnityEngine;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public class JsonConverter : MonoBehaviour{

	public static JSONObject objectToJsonObject(object obj){

		if(obj == null)
			return null;

		JSONObject _jsonObject = new JSONObject();

		if(obj.GetType() == typeof(ArrayList)){

			_jsonObject.AddField("arrayType", (string) ((ArrayList)obj)[0].GetType().FullName);

			JSONObject _jsonListObject = new JSONObject();

			foreach(object child in ((ArrayList)obj)){
								
				_jsonListObject.Add(objectToJsonObject(child));
				
			}

			_jsonObject.AddField("arrayList", _jsonListObject);

		}
		else if(obj.GetType().IsArray){

			_jsonObject.AddField("arrayType", (string) ((object[])obj)[0].GetType().FullName);
			
			JSONObject _jsonListObject = new JSONObject();

			foreach(object child in ((object[])obj)){
				
				_jsonListObject.Add(objectToJsonObject(child));
				
			}

			_jsonObject.AddField("arrayList", _jsonListObject);

		}
		else{

			foreach(FieldInfo field in obj.GetType()
			        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)){

				if(field.FieldType == typeof(string)){
					
					_jsonObject.AddField(field.Name, (string) field.GetValue(obj));
					
				}
				else if (field.FieldType.IsPrimitive){

					if(field.FieldType == typeof(int)){
						
						_jsonObject.AddField(field.Name, (int) field.GetValue(obj));
						
					}
					else if(field.FieldType == typeof(double) || field.FieldType == typeof(float)){
						
						_jsonObject.AddField(field.Name, (float) field.GetValue(obj));
						
					}
					else if(field.FieldType == typeof(bool)){
						
						_jsonObject.AddField(field.Name, (bool) field.GetValue(obj));
						
					}

				}
				else {

					_jsonObject.AddField(field.Name, objectToJsonObject(field.GetValue(obj)));

				}
				
			}

		}

		return _jsonObject;

	}

	public static string objectToJson(object obj){

		return objectToJsonObject(obj).print(false);

	}

	public static object jsonToObject(string json, System.Type classType){

		JSONObject _jsonObject = new JSONObject(json, false);

		return jsonObjectToObject(_jsonObject, classType);

	}

	public static object jsonObjectToObject(JSONObject jsonObject, System.Type classType){
		
		if(jsonObject == null)
			return null;
		
		object _obj = System.Activator.CreateInstance(classType);
		
		if(classType == typeof(ArrayList)){

			System.Type _arrayType = System.Type.GetType(
										 jsonObject.GetField("arrayType").str);
			
			foreach(JSONObject child in jsonObject.GetField("arrayList").list){

				((ArrayList)_obj).Add(jsonObjectToObject(child, _arrayType));
				
			}
			
		}
		else if(classType.IsArray){

			System.Type _arrayType = System.Type.GetType(
										 jsonObject.GetField("arrayType").str);

			int _index = 0;

			foreach(JSONObject child in jsonObject.GetField("arrayList").list){
				
				((object[])_obj)[_index] = jsonObjectToObject(child, _arrayType);

				_index++;
				
			}
			
		}
		else{
			
			foreach(FieldInfo field in classType
			        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)){
				
				if(field.FieldType == typeof(string)){

					field.SetValue(_obj, jsonObject.GetField(field.Name).str);
					
				}
				else if (field.FieldType.IsPrimitive){
					
					if(field.FieldType == typeof(int)){
						
						field.SetValue(_obj, (int) jsonObject.GetField(field.Name).n);
						
					}
					else if(field.FieldType == typeof(double) || field.FieldType == typeof(float)){
						
						field.SetValue(_obj, jsonObject.GetField(field.Name).n);
						
					}
					else if(field.FieldType == typeof(bool)){
						
						field.SetValue(_obj, jsonObject.GetField(field.Name).b);
						
					}
					
				}
				else {

					field.SetValue(_obj, jsonObjectToObject(jsonObject.GetField(field.Name), field.FieldType));
										
				}
				
			}
			
		}
		
		return _obj;
		
	}
	
}