import 'package:flutter/material.dart';

import 'cast.dart';
part 'actor.g.dart';

class Actor extends Cast {
  Actor();
  factory Actor.fromJson(Map<String, dynamic> json) => _$ActorFromJson(json);

  Map<String, dynamic> ActortoJson() => _$ActorToJson(this);
}
