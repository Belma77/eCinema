import 'package:flutter/material.dart';

import 'error.messages.dart';

class Validator {
  static String? validateEmail(String? value) {
    String pattern =
        r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
    RegExp regex = RegExp(pattern);
    if (value!.isEmpty) {
      return ErrorMessages.notEmptyValue;
    } else if (!regex.hasMatch(value)) {
      return ErrorMessages.emailNotValid;
    } else {
      return null;
    }
  }

  static String? validatePassword(String? value) {
    /* RegExp regex =
        RegExp(r'^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#\$&*~]).{8,}$');
    if (value!.isEmpty) {
      return ErrorMessages.notEmptyValue;
    } else if (!regex.hasMatch(value)) {
      return ErrorMessages.passwordNotValid;
    } else {
      return null;
    } */
    if (value!.isEmpty) {
      return ErrorMessages.notEmptyValue;
    } else if (value.length < 6) {
      return ErrorMessages.passwordNotValid;
    } else {
      return null;
    }
  }

  static String? validatePhone(String? value) {
    if (value!.isEmpty) {
      return ErrorMessages.notEmptyValue;
    } else if (value.length != 9 || double.tryParse(value) == null) {
      return ErrorMessages.phoneNotValid;
    }
    return null;
  }

  static String? validateName(String? value) {
    if (value!.isEmpty) return ErrorMessages.notEmptyValue;
    return null;
  }
}
