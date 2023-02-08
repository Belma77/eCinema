part of 'producer.dart';

Producer _$ProducerFromJson(Map<String, dynamic> json) => Producer()
  ..firstName = json['firstName'] as String
  ..lastName = json['lastName'] as String;

Map<String, dynamic> _$ProducerToJson(Producer instance) => <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName
    };
