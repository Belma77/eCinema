part 'genres.g.dart';

class Genres {
  String? genre;
  Genres();
  factory Genres.fromJson(Map<String, dynamic> json) => _$GenresFromJson(json);

  Map<String, dynamic> toJson() => _$GenresToJson(this);
  @override
  String toString() {
    // TODO: implement toString
    return genre.toString();
  }
}
