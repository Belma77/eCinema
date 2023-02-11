import 'dart:convert';

import 'package:ecinemamobile/models/Users/user.loyalty.dart';

import '../models/Users/user.dart';
import 'base.provider.dart';

class LoyaltyClubProvider extends BaseProvider<LoyalCard> {
  LoyaltyClubProvider() : super("LoyaltyClub");
  @override
  LoyalCard fromJson(data) {
    // TODO: implement fromJson
    return LoyalCard.fromJson(data);
  }
}
