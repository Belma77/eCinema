import 'package:flutter/material.dart';

import 'cast.dart';
part 'writer.g.dart';

class Writer extends Cast {
  Writer();
  factory Writer.fromJson(Map<String, dynamic> json) => _$WriterFromJson(json);

  Map<String, dynamic> WritertoJson() => _$WriterToJson(this);
}
