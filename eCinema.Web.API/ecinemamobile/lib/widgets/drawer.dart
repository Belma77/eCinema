import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

import '../screens/loyalty.club.dart';
import '../screens/user.profile.dart';

class DrawerWidget extends StatelessWidget {
  const DrawerWidget({super.key});

  @override
  Widget build(BuildContext context) {
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
              Navigator.pushNamed(context, "${UserProfile.route}");
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.card_membership,
            ),
            title: const Text('Join loyalty club'),
            onTap: () {
              Navigator.pushNamed(context, "${LoyaltyClubScreen.route}");
            },
          ),
          ListTile(
            leading: const Icon(
              Icons.logout,
            ),
            title: const Text('Sing out'),
            onTap: () {
              Navigator.pop(context);
            },
          ),
        ],
      ),
    );
  }
}
