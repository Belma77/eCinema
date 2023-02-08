import 'package:flutter/material.dart';

import 'cast.dart';
part 'director.g.dart';

class Director extends Cast {
  Director();
  factory Director.fromJson(Map<String, dynamic> json) =>
      _$DirectorFromJson(json);

  Map<String, dynamic> DirectortoJson() => _$DirectorToJson(this);
}
