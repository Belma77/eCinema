part of 'movies.actors.dart';

ActorsMovies _$ActorsMoviesFromJson(Map<String, dynamic> json) =>
    ActorsMovies()..actor = Cast.fromJson(json['actor']);

Map<String, dynamic> _$ActorsMoviesToJson(ActorsMovies instance) =>
    <String, dynamic>{'actor': instance.actor};
