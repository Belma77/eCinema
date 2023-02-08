import 'package:flutter/material.dart';

import 'cast.dart';
part 'producer.g.dart';

class Producer extends Cast {
  Producer();
  factory Producer.fromJson(Map<String, dynamic> json) =>
      _$ProducerFromJson(json);

  Map<String, dynamic> ProducertoJson() => _$ProducerToJson(this);
}
