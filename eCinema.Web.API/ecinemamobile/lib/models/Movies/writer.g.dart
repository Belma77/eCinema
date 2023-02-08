part of 'writer.dart';

Writer _$WriterFromJson(Map<String, dynamic> json) => Writer()
  ..firstName = json['firstName'] as String
  ..lastName = json['lastName'] as String;

Map<String, dynamic> _$WriterToJson(Writer instance) => <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName
    };
