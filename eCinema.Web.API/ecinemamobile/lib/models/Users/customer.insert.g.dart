part of 'customer.insert.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CustomerInsert _$CustomerInsertFromJson(Map<String, dynamic> json) {
  return CustomerInsert(
      json['firstName'] as String?,
      json['lastName'] as String?,
      json['phone'] as String?,
      json['email'] as String,
      null,
      null);
}

// ..picture = json['picture'] as String;

Map<String, dynamic> _$CustomerInsertToJson(CustomerInsert instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'phone': instance.phone,
      'username': instance.username,
      'password': instance.password,
    };
