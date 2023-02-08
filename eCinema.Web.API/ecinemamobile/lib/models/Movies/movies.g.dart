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
  List<Schedule> _schedules = [];

  var genresMovies = json['moviesGenres'] as List;
  _genresMovies = genresMovies.map((x) => GenresMovies.fromJson(x)).toList();

  var actorsMovies = json['actorsMovies'] as List;
  _actorsMovies = actorsMovies.map((x) => ActorsMovies.fromJson(x)).toList();

  var directorsMovies = json['directorsMovies'] as List;
  _directorsMovies =
      directorsMovies.map((x) => DirectorsMovies.fromJson(x)).toList();

  var writersMovies = json['writersMovies'] as List;
  _writersMovies = writersMovies.map((x) => WritersMovies.fromJson(x)).toList();

  var producersMovies = json['producersMovies'] as List;
  _producersMovies =
      producersMovies.map((x) => ProducersMovies.fromJson(x)).toList();

  /*  var schedules = json['schedules'] as List;
  _schedules = schedules.map((x) => Schedule.fromJson(x)).toList(); */

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
      _producersMovies);
  //     _schedules);
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
      //  'schedules': instance.schedules
    };
