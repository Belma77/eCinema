import 'dart:convert';
import 'dart:ffi';
import 'package:ecinemamobile/models/Movies/genres.movies.dart';
import 'package:ecinemamobile/models/Movies/movies.actors.dart';
import 'package:ecinemamobile/models/Schedules/schedule.dart';
import 'package:json_annotation/json_annotation.dart';

import '../Schedules/schedule.movie.dart';
import 'movies.directors.dart';
import 'movies.producer.dart';
import 'movies.writers.dart';
part 'movies.g.dart';

@JsonSerializable()
class Movies {
  int? id;
  String? title;
  int? releaseYear;
  int? duration;
  String? country;
  String? poster;
  String? synopsis;
  List<GenresMovies> genresMovies = [];
  List<ActorsMovies>? actorsMovies = [];
  List<DirectorsMovies>? directorsMovies = [];
  List<WritersMovies>? writersMovies = [];
  List<ProducersMovies>? producersMovies = [];
  List<ScheduleMovie>? schedules = [];

  Movies(
      this.id,
      this.title,
      this.releaseYear,
      this.duration,
      this.country,
      this.poster,
      this.synopsis,
      this.genresMovies,
      this.actorsMovies,
      this.directorsMovies,
      this.writersMovies,
      this.producersMovies,
      [this.schedules]);

  factory Movies.fromJson(Map<String, dynamic> json) => _$MoviesFromJson(json);

  Map<String, dynamic> toJson() => _$MoviesToJson(this);
}
