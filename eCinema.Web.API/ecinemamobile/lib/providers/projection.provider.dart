import '../models/Schedules/projection.dart';
import '../models/Schedules/schedule.dart';
import 'base.provider.dart';

class ProjectionProvider extends BaseProvider<Projection> {
  ProjectionProvider() : super("Schedule");

  @override
  Projection fromJson(data) {
    return Projection.fromJson(data);
  }
}
