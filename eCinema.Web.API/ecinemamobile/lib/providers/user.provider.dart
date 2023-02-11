import '../models/Users/user.dart';
import 'base.provider.dart';

class UserProvider extends BaseProvider<Customer> {
  UserProvider() : super("Customer");

  @override
  Customer fromJson(data) {
    // TODO: implement fromJson
    return Customer.fromJson(data);
  }
}
