part of 'user.loyalty.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LoyalCard _$LoyalCardFromJson(Map<String, dynamic> json) =>
    LoyalCard()..customerId = json['customerId'] as int;

Map<String, dynamic> _$LoyalCardToJson(LoyalCard instance) => <String, dynamic>{
      'customerId': instance.customerId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'phone': instance.phone,
      'email': instance.email,
      'city': instance.city,
      'identificationNumber': instance.identificationNumber,
      'username': instance.username,
      'paymentID': instance.paymentID
    };
