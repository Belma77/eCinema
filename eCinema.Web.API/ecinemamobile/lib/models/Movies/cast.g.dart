part of 'cast.dart';

Cast _$CastFromJson(Map<String, dynamic> json) => Cast()
  ..firstName = json['firstName'] as String
  ..lastName = json['lastName'] as String;

Map<String, dynamic> _$CastToJson(Cast instance) => <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName
    };
