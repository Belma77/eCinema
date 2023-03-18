part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Customer _$UserFromJson(Map<String, dynamic> json) {
  if (json['profilePicture'] != null) {
    return Customer(
        json['id'] as int?,
        json['firstName'] as String?,
        json['lastName'] as String?,
        json['phone'] as String?,
        json['email'] as String?,
        json['username'] as String?,
        json['profilePicture'] as String?);
  }
  return Customer(
      json['id'] as int?,
      json['firstName'] as String?,
      json['lastName'] as String?,
      json['phone'] as String?,
      json['email'] as String?,
      json['username'] as String?);
}

Map<String, dynamic> _$UserToJson(Customer instance) => <String, dynamic>{
      'id': instance.id,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'phone': instance.phone,
      'username': instance.username,
      'picture': instance.profilePicture
    };
