part of 'movies.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************
Movies _$MoviesFromJson(Map<String, dynamic> json) {
  List<ActorsMovies> _actorsMovies = [];
  List<DirectorsMovies> _directorsMovies = [];
  List<WritersMovies> _writersMovies = [];
  List<ProducersMovies> _producersMovies = [];
  List<GenresMovies> _genresMovies = [];
  List<ScheduleMovie> _schedules = [];

  if (json['moviesGenres'] != null) {
    var genresMovies = json['moviesGenres'] as List;
    _genresMovies = genresMovies.map((x) => GenresMovies.fromJson(x)).toList();
  }

  if (json['actorsMovies'] != null) {
    var actorsMovies = json['actorsMovies'] as List;
    _actorsMovies = actorsMovies.map((x) => ActorsMovies.fromJson(x)).toList();
  }

  if (json['directorsMovies'] != null) {
    var directorsMovies = json['directorsMovies'] as List;
    _directorsMovies =
        directorsMovies.map((x) => DirectorsMovies.fromJson(x)).toList();
  }

  if (json['writersMovies'] != null) {
    var writersMovies = json['writersMovies'] as List;
    _writersMovies =
        writersMovies.map((x) => WritersMovies.fromJson(x)).toList();
  }

  if (json['producersMovies'] != null) {
    var producersMovies = json['producersMovies'] as List;
    _producersMovies =
        producersMovies.map((x) => ProducersMovies.fromJson(x)).toList();
  }
  if (json['schedules'] != null) {
    var schedules = json['schedules'] as List;
    _schedules = schedules.map((x) => ScheduleMovie.fromJson(x)).toList();
  }
  return Movies(
      json['id'] as int,
      json['title'] as String,
      json['releaseYear'] as int,
      json['duration'] as int,
      json['country'] as String,
      json['poster'] as String,
      json['synopsis'] as String,
      _genresMovies,
      _actorsMovies,
      _directorsMovies,
      _writersMovies,
      _producersMovies,
      _schedules);
}

Map<String, dynamic> _$MoviesToJson(Movies instance) => <String, dynamic>{
      'id': instance.id,
      'title': instance.title,
      'country': instance.country,
      'duration': instance.duration,
      'releaseYear': instance.releaseYear,
      'poster': instance.poster,
      'synposis': instance.synopsis,
      'genresMovies': instance.genresMovies,
      'actorsMovies': instance.actorsMovies,
      'directorsMovies': instance.directorsMovies,
      'writersMovies': instance.writersMovies,
      'producersMovies': instance.producersMovies,
      'schedules': instance.schedules
    };
