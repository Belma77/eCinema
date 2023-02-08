import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';
part 'cast.g.dart';

@JsonSerializable()
class Cast {
  String? firstName;
  String? lastName;
  Cast() {}

  factory Cast.fromJson(Map<String, dynamic> json) => _$CastFromJson(json);

  Map<String, dynamic> toJson() => _$CastToJson(this);
}
