part of 'actor.dart';

Actor _$ActorFromJson(Map<String, dynamic> json) => Actor()
  ..firstName = json['firstName'] as String
  ..lastName = json['lastName'] as String;

Map<String, dynamic> _$ActorToJson(Actor instance) => <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName
    };
