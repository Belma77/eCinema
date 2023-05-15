part 'payment.g.dart';

class Payment {
  String id;

  Payment(this.id);
  factory Payment.fromJson(Map<dynamic, dynamic> json) =>
      _$PaymentFromJson(json);

  Map<String, dynamic> toJson() => _$PaymentToJson(this);
}
