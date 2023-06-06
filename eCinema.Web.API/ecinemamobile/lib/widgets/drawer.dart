import 'package:ecinemamobile/models/Authorization/authorization.dart';
import 'package:ecinemamobile/screens/login.screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../providers/schedule.provider.dart';
import '../screens/loyalty.club.dart';
import '../screens/user.profile.dart';

class DrawerWidget extends StatelessWidget {
  DrawerWidget({super.key});
  late ScheduleProvider _scheduleProvider;

  @override
  Widget build(BuildContext context) {
    _scheduleProvider = Provider.of<ScheduleProvider>(context, listen: false);
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: [
          const SizedBox(
            height: 100,
            child: DrawerHeader(
              decoration: BoxDecoration(
                color: Color.fromARGB(255, 205, 202, 202),
              ),
              child: Center(child: Text('Navigation menu')),
            ),
          ),
          ListTile(
            leading: const Icon(
              Icons.person,
            ),
            title: const Text('Edit profile'),
            onTap: () {
              Navigator.pushNamed(context, UserProfile.route);
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.card_membership,
            ),
            title: const Text('Join loyalty club'),
            onTap: () {
              Navigator.pushNamed(context, LoyaltyClubScreen.route);
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.logout,
            ),
            title: const Text('Log out'),
            onTap: () async {
              try {
                Authorization.username = "";
                Authorization.password = "";
                await _scheduleProvider.get();
              } catch (e) {
                showDialog(
                    context: context,
                    builder: (BuildContext context) => AlertDialog(
                          title: const Text("Logout"),
                          content: const Text("Successfuly logged out"),
                          actions: [
                            TextButton(
                              child: const Text("Ok"),
                              onPressed: () => Navigator.pushNamed(
                                  context, LoginScreen.route),
                            )
                          ],
                        ));
              }
            },
          ),
        ],
      ),
    );
  }
}
