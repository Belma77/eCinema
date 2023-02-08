part of 'director.dart';

Director _$DirectorFromJson(Map<String, dynamic> json) => Director()
  ..firstName = json['firstName'] as String
  ..lastName = json['lastName'] as String;

Map<String, dynamic> _$DirectorToJson(Director instance) => <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName
    };
