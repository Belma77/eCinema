import 'dart:ui';

import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:json_annotation/json_annotation.dart';
part 'customer.insert.g.dart';

@JsonSerializable()
class CustomerInsert {
  String? firstName;
  String? lastName;
  String? phone;
  String? email;
  String? username;
  String? password;

  CustomerInsert(this.firstName, this.lastName, this.phone, this.email,
      this.username, this.password);

  factory CustomerInsert.fromJson(Map<String, dynamic> json) =>
      _$CustomerInsertFromJson(json);

  Map<String, dynamic> toJson() => _$CustomerInsertToJson(this);
}
