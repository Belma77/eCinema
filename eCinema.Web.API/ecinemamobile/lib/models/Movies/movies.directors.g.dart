part of 'movies.directors.dart';

DirectorsMovies _$DirectorsMoviesFromJson(Map<String, dynamic> json) =>
    DirectorsMovies()..director = Cast.fromJson(json['director']);

Map<String, dynamic> _$DirectorsMoviesToJson(DirectorsMovies instance) =>
    <String, dynamic>{'director': instance.director};
