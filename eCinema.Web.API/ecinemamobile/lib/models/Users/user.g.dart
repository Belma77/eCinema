part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Customer _$UserFromJson(Map<String, dynamic> json) {
  return Customer(
      json['id'] as int?,
      json['firstName'] as String?,
      json['lastName'] as String?,
      json['phone'] as String?,
      json['email'] as String?,
      json['username'] as String?);
}

// ..picture = json['picture'] as String;

Map<String, dynamic> _$UserToJson(Customer instance) => <String, dynamic>{
      'id': instance.Id,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'phone': instance.phone,
      'username': instance.username,
      // 'picture': instance.picture
    };
