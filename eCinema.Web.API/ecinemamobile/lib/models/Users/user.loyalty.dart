import 'package:ecinemamobile/models/Users/user.dart';
import 'package:json_annotation/json_annotation.dart';

import 'customer.type.dart';
part 'user.loyalty.g.dart';

@JsonSerializable()
class LoyalCard {
  int? customerId;
  String? firstName;
  String? lastName;
  String? phone;
  String? email;
  String? username;
  String? city;
  String? identificationNumber;
  LoyalCard();

  factory LoyalCard.fromJson(Map<String, dynamic> json) =>
      _$LoyalCardFromJson(json);

  Map<String, dynamic> toJson() => _$LoyalCardToJson(this);
}
