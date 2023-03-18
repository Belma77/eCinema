import 'package:intl/intl.dart';
import 'package:json_annotation/json_annotation.dart';

class CustomDateTimeConverter implements JsonConverter<DateTime, String> {
  const CustomDateTimeConverter();

  @override
  DateTime fromJson(String json) {
    if (json.contains(".")) {
      json = json.substring(0, json.length - 1);
    }

    return DateTime.parse(json);
  }

  @override
  String toJson(DateTime json) => json.toIso8601String();
}

String formatTime(DateTime date) {
  if (dynamic == null) {
    return "";
  }

  var f = DateFormat.jm();

  return f.format(date);
}

String formatDate(DateTime date) {
  if (dynamic == null) {
    return "";
  }

  var f = DateFormat.yMMMMd();

  return f.format(date);
}

String formatShortDate(DateTime date) {
  if (dynamic == null) {
    return "";
  }

  var day = date.day.toString();
  var month = date.month.toString();

  return "$day.$month";
}
