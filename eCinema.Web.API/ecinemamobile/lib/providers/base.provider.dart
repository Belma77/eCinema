import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:ecinemamobile/env.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import '../models/Authorization/authorization.dart';
import '../models/Users/user.loyalty.dart';

abstract class BaseProvider<T> with ChangeNotifier {
  static String? _baseUrl;
  static String? _endpoint;
  static Map<String, dynamic>? paymentIntent;

  HttpClient client = new HttpClient();
  IOClient? http;

  BaseProvider(String endpoint) {
    _baseUrl = const String.fromEnvironment("baseUrl",
        defaultValue: "https://10.0.2.2:7239/");
    print("baseurl: $_baseUrl");

    if (_baseUrl!.endsWith("/") == false) {
      _baseUrl = _baseUrl! + "/";
    }

    _endpoint = endpoint;
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
  }
  String? get getbaseUrl => _baseUrl;

  Future<T> getById(int id, [dynamic additionalData]) async {
    var url = Uri.parse("$_baseUrl$_endpoint/$id");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);
    print("done $response");

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      print(data);
      print("uspjesno");

      var map = fromJson(data);
      return map;
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<List<T>> get([dynamic search]) async {
    var url = "$_baseUrl$_endpoint";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    print("get me");
    var response = await http!.get(uri, headers: headers);
    print("done $response");
    if (isValidResponseCode(response)) {
      print("uspjesno");
      var data = jsonDecode(response.body);
      print(data);
      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<List<T>> getRecommendation(int id, String path) async {
    var url = "$_baseUrl$_endpoint/$id/$path";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    print("get me");
    var response = await http!.get(uri, headers: headers);
    print("done $response");
    if (isValidResponseCode(response)) {
      print("uspjesno");
      var data = jsonDecode(response.body);
      print(data);
      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<void> makePayment() async {
    try {
      await Stripe.instance
          .initPaymentSheet(
              paymentSheetParameters: SetupPaymentSheetParameters(
                  paymentIntentClientSecret: paymentIntent!['client_secret'],
                  style: ThemeMode.dark,
                  merchantDisplayName: 'Merchant Name'))
          .then((value) => {});
    } catch (err) {}
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };
      var url = "https://api.stripe.com/v1/payment_intents";
      var response = await http!.post(Uri.parse(url),
          headers: {
            'Authorization': 'Bearer $SECRET_KEY',
            'Content-Type': 'application/x-www-form-urlencoded'
          },
          body: body);
      paymentIntent = jsonDecode(response.body);
      await makePayment();
      return jsonDecode(response.body);
    } catch (err) {
      print('error${err.toString()}');
    }
  }

  Future<T> getUser() async {
    var url = "$_baseUrl$_endpoint/Current";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    print("get me");
    var response = await http!.get(uri, headers: headers);
    print("done $response");
    if (isValidResponseCode(response)) {
      print("uspjesno");
      var data = jsonDecode(response.body);
      print(data);
      var map = fromJson(data);
      return map;
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<T?> insert(dynamic request) async {
    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var jsonRequest = jsonEncode(request);
    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }

  Future<T?> update(int id, [dynamic request]) async {
    var url = "$_baseUrl$_endpoint/$id";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response =
        await http!.put(uri, headers: headers, body: jsonEncode(request));

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data) as T;
    } else {
      return null;
    }
  }

  Future<List<T>> delete(int id) async {
    var url = Uri.parse("$_baseUrl$_endpoint/$id");

    Map<String, String> headers = createHeaders();

    var response = await http!.delete(url, headers: headers);
    print("done $response");

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      print(data);
      print("uspjesno");

      return data.map((x) => fromJson(x)).cast<T>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Map<String, String> createHeaders() {
    String? username = Authorization.username;
    String? password = Authorization.password;

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };
    return headers;
  }

  T fromJson(data) {
    throw Exception("Override method");
  }

  String getQueryString(Map params,
      {String prefix: '&', bool inRecursion: false}) {
    String query = '';
    params.forEach((key, value) {
      if (inRecursion) {
        if (key is int) {
          key = '[$key]';
        } else if (value is List || value is Map) {
          key = '.$key';
        } else {
          key = '.$key';
        }
      }
      if (value is String || value is int || value is double || value is bool) {
        var encoded = value;
        if (value is String) {
          encoded = Uri.encodeComponent(value);
        }
        query += '$prefix$key=$encoded';
      } else if (value is DateTime) {
        query += '$prefix$key=${(value as DateTime).toIso8601String()}';
      } else if (value is List || value is Map) {
        if (value is List) value = value.asMap();
        value.forEach((k, v) {
          query +=
              getQueryString({k: v}, prefix: '$prefix$key', inRecursion: true);
        });
      }
    });
    return query;
  }

  bool isValidResponseCode(Response response) {
    if (response.statusCode == 200) {
      if (response.body != "") {
        return true;
      } else {
        return false;
      }
    } else if (response.statusCode == 204) {
      return true;
    } else if (response.statusCode == 400) {
      throw Exception("Bad request");
    } else if (response.statusCode == 401) {
      throw Exception("Unauthorized");
    } else if (response.statusCode == 403) {
      throw Exception("Forbidden");
    } else if (response.statusCode == 404) {
      throw Exception("Not found");
    } else if (response.statusCode == 500) {
      throw Exception("Internal server error");
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
