import 'dart:convert';

import 'package:ecinemamobile/models/Movies/movies.dart';

import 'base.provider.dart';

class MoviesProvider extends BaseProvider<Movies> {
  MoviesProvider() : super("Movies");
  final _baseUrl = const String.fromEnvironment("baseUrl",
      defaultValue: "https://10.0.2.2:7239/");
  final _endpoint = "Movies";

  @override
  Movies fromJson(data) {
    // TODO: implement fromJson
    return Movies.fromJson(data);
  }

  Future<List<Movies>> getRecommendation(int id, String path) async {
    var url = "$_baseUrl$_endpoint/$id/$path";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Movies>().toList();
    } else {
      throw Exception("Ups.. something went wrong");
    }
  }
}
