import 'dart:ui';

import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:json_annotation/json_annotation.dart';
part 'user.g.dart';

@JsonSerializable()
class Customer {
  int? id;
  String? firstName;
  String? lastName;
  String? phone;
  String? email;
  String? username;
  //String? picture;

  Customer(
    this.id,
    this.firstName,
    this.lastName,
    this.phone,
    this.email,
    this.username,
  );

  Customer.paramterless();
  factory Customer.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  Map<String, dynamic> toJson() => _$UserToJson(this);
}
