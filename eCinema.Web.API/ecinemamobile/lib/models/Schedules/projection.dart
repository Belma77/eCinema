import 'dart:convert';
import 'dart:ffi';
import 'package:ecinemamobile/models/Movies/genres.movies.dart';
import 'package:ecinemamobile/models/Movies/movies.actors.dart';
import 'package:ecinemamobile/models/Schedules/schedule.dart';
import 'package:json_annotation/json_annotation.dart';
part 'projection.g.dart';

@JsonSerializable()
class Projection {
  int? id;
  String? title;
  int? releaseYear;
  int? duration;
  String? country;
  String? poster;
  String? synopsis;
  List<GenresMovies> genresMovies = [];
  List<ActorsMovies>? actorsMovies = [];

  Projection(
    this.id,
    this.title,
    this.releaseYear,
    this.duration,
    this.country,
    this.poster,
    this.synopsis,
    this.genresMovies,
    this.actorsMovies,
  );

  factory Projection.fromJson(Map<String, dynamic> json) =>
      _$ProjectionFromJson(json);

  Map<String, dynamic> toJson() => _$ProjectionToJson(this);

  bool equals(Projection item) {
    if (item.title == title) return true;
    return false;
  }
}
