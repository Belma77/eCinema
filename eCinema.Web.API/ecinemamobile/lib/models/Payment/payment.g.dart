part of 'payment.dart';

Payment _$PaymentFromJson(Map<dynamic, dynamic> json) {
  return Payment(json['id'] as String);
}

Map<String, dynamic> _$PaymentToJson(Payment instance) {
  var obj = <String, dynamic>{'id': instance.id};
  return obj;
}
