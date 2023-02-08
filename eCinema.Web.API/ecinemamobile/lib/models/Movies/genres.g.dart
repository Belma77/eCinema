part of 'genres.dart';

Genres _$GenresFromJson(Map<String, dynamic> json) =>
    Genres()..genre = json['genre'];

Map<String, dynamic> _$GenresToJson(Genres instance) =>
    <String, dynamic>{'genre': instance.genre};
