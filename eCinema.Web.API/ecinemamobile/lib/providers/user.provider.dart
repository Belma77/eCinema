import '../models/Users/user.dart';
import 'base.provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("Customer");

  @override
  User fromJson(data) {
    // TODO: implement fromJson
    return User();
  }
}
