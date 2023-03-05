import 'dart:convert';

import '../env.dart';
import '../models/Users/customer.insert.dart';
import '../models/Users/user.dart';
import 'base.provider.dart';

class UserProvider extends BaseProvider<Customer> {
  UserProvider() : super("Customer");
  final _baseUrl =
      const String.fromEnvironment("baseUrl", defaultValue: baseUrl);
  final _endpoint = "Customer";

  @override
  Customer fromJson(data) {
    return Customer.fromJson(data);
  }

  Future<Customer> getUser() async {
    var url = "$_baseUrl$_endpoint/Current";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    print(response);
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      var map = fromJson(data);
      return map;
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }

  Future<CustomerInsert?> register(dynamic request) async {
    var url = "$_baseUrl$_endpoint";
    var uri = Uri.parse(url);

    var jsonRequest = jsonEncode(request);
    var headers = {
      "Content-Type": "application/json",
    };
    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return CustomerInsert.fromJson(data);
    } else {
      return null;
    }
  }

  Future<List<Customer>> getByUsername([dynamic search]) async {
    var url = "$_baseUrl$_endpoint";

    if (search != null) {
      String queryString = getQueryString(search);
      url = url + "?" + queryString;
    }

    var uri = Uri.parse(url);
    var headers = {
      "Content-Type": "application/json",
    };
    var response = await http!.get(uri, headers: headers);

    print(response);
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<Customer>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
