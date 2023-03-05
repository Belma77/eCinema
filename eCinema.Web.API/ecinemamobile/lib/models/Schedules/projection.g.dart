part of 'projection.dart';
// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Projection _$ProjectionFromJson(Map<String, dynamic> json) {
  List<ActorsMovies> _actorsMovies = [];
  List<GenresMovies> _genresMovies = [];

  if (json['moviesGenres'] != null) {
    var genresMovies = json['moviesGenres'] as List;
    _genresMovies = genresMovies.map((x) => GenresMovies.fromJson(x)).toList();
  }

  if (json['actorsMovies'] != null) {
    var actorsMovies = json['actorsMovies'] as List;
    _actorsMovies = actorsMovies.map((x) => ActorsMovies.fromJson(x)).toList();
  }

  return Projection(
    json['id'] as int,
    json['title'] as String,
    json['releaseYear'] as int,
    json['duration'] as int,
    json['country'] as String,
    json['poster'] as String,
    json['synopsis'] as String,
    _genresMovies,
    _actorsMovies,
  );
}

Map<String, dynamic> _$ProjectionToJson(Projection instance) =>
    <String, dynamic>{
      'id': instance.id,
      'title': instance.title,
      'country': instance.country,
      'duration': instance.duration,
      'releaseYear': instance.releaseYear,
      'poster': instance.poster,
      'synposis': instance.synopsis,
      'genresMovies': instance.genresMovies,
      'actorsMovies': instance.actorsMovies,
    };
