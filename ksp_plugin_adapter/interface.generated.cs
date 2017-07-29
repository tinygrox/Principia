// Warning!  This file was generated by running a program (see project |tools|).
// If you change it, the changes will be lost the next time the generator is
// run.  You should change the generator instead.

using System;
using System.Runtime.InteropServices;

namespace principia {
namespace ksp_plugin_adapter {

[StructLayout(LayoutKind.Sequential)]
internal partial struct NavigationFrameParameters {
  public int extension;
  public int centre_index;
  public int primary_index;
  public int secondary_index;
  private Byte boule_;
  public bool boule {
    get { return boule_ != (Byte)0; }
    set { boule_ = value ? (Byte)1 : (Byte)0; }
  }
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct XYZ {
  public double x;
  public double y;
  public double z;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct AdaptiveStepParameters {
  public Int64 integrator_kind;
  public Int64 max_steps;
  public double length_integration_tolerance;
  public double speed_integration_tolerance;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct BodyParameters {
  public String name;
  public String gravitational_parameter;
  public String reference_instant;
  public String mean_radius;
  public String axis_right_ascension;
  public String axis_declination;
  public String reference_angle;
  public String angular_frequency;
  public String j2;
  public String reference_radius;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct Burn {
  public double thrust_in_kilonewtons;
  public double specific_impulse_in_seconds_g0;
  public NavigationFrameParameters frame;
  public double initial_time;
  public XYZ delta_v;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct KeplerianElements {
  public double eccentricity;
  public double semimajor_axis;
  public double mean_motion;
  public double inclination_in_degrees;
  public double longitude_of_ascending_node_in_degrees;
  public double argument_of_periapsis_in_degrees;
  public double mean_anomaly;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct NavigationManoeuvre {
  public Burn burn;
  public double initial_mass_in_tonnes;
  public double final_mass_in_tonnes;
  public double mass_flow;
  public double duration;
  public double final_time;
  public double time_of_half_delta_v;
  public double time_to_half_delta_v;
  public XYZ inertial_direction;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct NavigationManoeuvreFrenetTrihedron {
  public XYZ binormal;
  public XYZ normal;
  public XYZ tangent;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct QP {
  public XYZ q;
  public XYZ p;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct WXYZ {
  public double w;
  public double x;
  public double y;
  public double z;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct XY {
  public double x;
  public double y;
}

internal static partial class Interface {

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__AdvanceTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void AdvanceTime(
      this IntPtr plugin,
      double t,
      double planetarium_rotation);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CatchUpLaggingVessels",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void CatchUpLaggingVessels(
      this IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CatchUpVessel",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void CatchUpVessel(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CelestialFromParent",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP CelestialFromParent(
      this IntPtr plugin,
      int celestial_index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CelestialInitialRotationInDegrees",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double CelestialInitialRotationInDegrees(
      this IntPtr plugin,
      int celestial_index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CelestialRotation",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern WXYZ CelestialRotation(
      this IntPtr plugin,
      int index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CelestialRotationPeriod",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double CelestialRotationPeriod(
      this IntPtr plugin,
      int celestial_index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CelestialSphereRotation",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern WXYZ CelestialSphereRotation(
      this IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CelestialWorldDegreesOfFreedom",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP CelestialWorldDegreesOfFreedom(
      this IntPtr plugin,
      int index,
      uint part_at_origin,
      double time);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__ClearTargetVessel",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void ClearTargetVessel(
      this IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__CurrentTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double CurrentTime(
      this IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__DeletePlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeletePlugin(
      ref IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__DeleteString",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeleteString(
      ref IntPtr native_string);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__DeserializePlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeserializePlugin(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String serialization,
      int serialization_size,
      ref IntPtr deserializer,
      ref IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__EndInitialization",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void EndInitialization(
      this IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanAppend",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool FlightPlanAppend(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      Burn burn);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanCreate",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanCreate(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      double final_time,
      double mass_in_tonnes);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanDelete",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanDelete(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanExists",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool FlightPlanExists(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanGetAdaptiveStepParameters",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern AdaptiveStepParameters FlightPlanGetAdaptiveStepParameters(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanGetActualFinalTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double FlightPlanGetActualFinalTime(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanGetDesiredFinalTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double FlightPlanGetDesiredFinalTime(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanGetInitialTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double FlightPlanGetInitialTime(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanGetManoeuvre",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern NavigationManoeuvre FlightPlanGetManoeuvre(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      int index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanGetManoeuvreFrenetTrihedron",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern NavigationManoeuvreFrenetTrihedron FlightPlanGetManoeuvreFrenetTrihedron(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      int index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanNumberOfManoeuvres",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int FlightPlanNumberOfManoeuvres(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanNumberOfSegments",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int FlightPlanNumberOfSegments(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanRemoveLast",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanRemoveLast(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanRenderedApsides",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanRenderedApsides(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      int celestial_index,
      XYZ sun_world_position,
      out IntPtr apoapsides,
      out IntPtr periapsides);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanRenderedClosestApproaches",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanRenderedClosestApproaches(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position,
      out IntPtr closest_approaches);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanRenderedNodes",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanRenderedNodes(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position,
      out IntPtr ascending,
      out IntPtr descending);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanRenderedSegment",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr FlightPlanRenderedSegment(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position,
      int index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanReplaceLast",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool FlightPlanReplaceLast(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      Burn burn);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanSetAdaptiveStepParameters",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool FlightPlanSetAdaptiveStepParameters(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      AdaptiveStepParameters adaptive_step_parameters);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FlightPlanSetDesiredFinalTime",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool FlightPlanSetDesiredFinalTime(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      double final_time);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__ForgetAllHistoriesBefore",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void ForgetAllHistoriesBefore(
      this IntPtr plugin,
      double t);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__FreeVesselsAndPartsAndCollectPileUps",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FreeVesselsAndPartsAndCollectPileUps(
      this IntPtr plugin,
      double delta_t);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetBufferDuration",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetBufferDuration();

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetBufferedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetBufferedLogging();

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetPartActualDegreesOfFreedom",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP GetPartActualDegreesOfFreedom(
      this IntPtr plugin,
      uint part_id,
      uint part_at_origin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetPlottingFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr GetPlottingFrame(
      IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetStderrLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetStderrLogging();

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetSuppressedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetSuppressedLogging();

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetVerboseLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetVerboseLogging();

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__GetVersion",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void GetVersion(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OutUTF8Marshaler))] out String build_date,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OutUTF8Marshaler))] out String version);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__HasEncounteredApocalypse",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool HasEncounteredApocalypse(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OutOwnedUTF8Marshaler))] out String details);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__HasVessel",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool HasVessel(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IncrementPartIntrinsicForce",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void IncrementPartIntrinsicForce(
      this IntPtr plugin,
      uint part_id,
      XYZ force_in_kilonewtons);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__InsertCelestialAbsoluteCartesian",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertCelestialAbsoluteCartesian(
      this IntPtr plugin,
      int celestial_index,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OptionalMarshaler<int>))] BoxedInt32 parent_index,
      BodyParameters body_parameters,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String x,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String y,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String z,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vx,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vy,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vz);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__InsertCelestialJacobiKeplerian",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertCelestialJacobiKeplerian(
      this IntPtr plugin,
      int celestial_index,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OptionalMarshaler<int>))] BoxedInt32 parent_index,
      BodyParameters body_parameters,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OptionalMarshaler<KeplerianElements>))] BoxedKeplerianElements keplerian_elements);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__InsertOrKeepVessel",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertOrKeepVessel(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_name,
      int parent_index,
      [MarshalAs(UnmanagedType.I1)] bool loaded,
      [MarshalAs(UnmanagedType.I1)] out bool inserted);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__InsertOrKeepLoadedPart",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertOrKeepLoadedPart(
      this IntPtr plugin,
      uint part_id,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String name,
      double mass_in_tonnes,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      int main_body_index,
      QP main_body_world_degrees_of_freedom,
      QP part_world_degrees_of_freedom,
      double delta_t);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__InsertUnloadedPart",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertUnloadedPart(
      this IntPtr plugin,
      uint part_id,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String name,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      QP from_parent);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorAtEnd",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.I1)]
  internal static extern bool IteratorAtEnd(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorDelete",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void IteratorDelete(
      ref IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorGetDiscreteTrajectoryQP",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP IteratorGetDiscreteTrajectoryQP(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorGetDiscreteTrajectoryTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double IteratorGetDiscreteTrajectoryTime(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorGetDiscreteTrajectoryXYZ",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ IteratorGetDiscreteTrajectoryXYZ(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorGetRP2LinesIterator",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr IteratorGetRP2LinesIterator(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorGetRP2LineXY",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XY IteratorGetRP2LineXY(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorIncrement",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void IteratorIncrement(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorReset",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void IteratorReset(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__IteratorSize",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int IteratorSize(
      this IntPtr iterator);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__LogError",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogError(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String text);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__LogFatal",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogFatal(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String text);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__LogInfo",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogInfo(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String text);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__LogWarning",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogWarning(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String text);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__NavballOrientation",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern WXYZ NavballOrientation(
      this IntPtr plugin,
      XYZ sun_world_position,
      XYZ ship_world_position);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__NewNavigationFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr NewNavigationFrame(
      this IntPtr plugin,
      NavigationFrameParameters parameters);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__NewPlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr NewPlugin(
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String game_epoch,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String solar_system_epoch,
      double planetarium_rotation_in_degrees);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__PlanetariumCreate",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr PlanetariumCreate(
      this IntPtr plugin,
      XYZ sun_world_position,
      XYZ xyz_opengl_camera_x_in_world,
      XYZ xyz_opengl_camera_y_in_world,
      XYZ xyz_opengl_camera_z_in_world,
      XYZ xyz_camera_position_in_world,
      double focal);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__PlanetariumDelete",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void PlanetariumDelete(
      ref IntPtr planetarium);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__PlanetariumPlotPrediction",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr PlanetariumPlotPrediction(
      this IntPtr planetarium,
      IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__PlanetariumPlotPsychohistory",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr PlanetariumPlotPsychohistory(
      this IntPtr planetarium,
      IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__PrepareToReportCollisions",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void PrepareToReportCollisions(
      this IntPtr plugin);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__RenderedPrediction",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr RenderedPrediction(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__RenderedPredictionApsides",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void RenderedPredictionApsides(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      int celestial_index,
      XYZ sun_world_position,
      out IntPtr apoapsides,
      out IntPtr periapsides);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__RenderedPredictionClosestApproaches",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void RenderedPredictionClosestApproaches(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position,
      out IntPtr closest_approaches);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__RenderedPredictionNodes",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void RenderedPredictionNodes(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position,
      out IntPtr ascending,
      out IntPtr descending);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__RenderedVesselTrajectory",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr RenderedVesselTrajectory(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      XYZ sun_world_position);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__ReportCollision",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void ReportCollision(
      this IntPtr plugin,
      uint part1_id,
      uint part2_id);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SayHello",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OutUTF8Marshaler))]
  internal static extern String SayHello();

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SerializePlugin",
             CallingConvention = CallingConvention.Cdecl)]
  [return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(OutOwnedUTF8Marshaler))]
  internal static extern String SerializePlugin(
      this IntPtr plugin,
      ref IntPtr serializer);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetBufferDuration",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetBufferDuration(
      int seconds);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetBufferedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetBufferedLogging(
      int max_severity);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetMainBody",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetMainBody(
      this IntPtr plugin,
      int index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetPartApparentDegreesOfFreedom",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPartApparentDegreesOfFreedom(
      this IntPtr plugin,
      uint part_id,
      QP degrees_of_freedom);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetPlottingFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPlottingFrame(
      this IntPtr plugin,
      ref IntPtr navigation_frame);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetPredictionLength",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPredictionLength(
      this IntPtr plugin,
      double t);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetTargetVessel",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetTargetVessel(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      int reference_body_index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetStderrLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetStderrLogging(
      int min_severity);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetSuppressedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetSuppressedLogging(
      int min_severity);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__SetVerboseLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetVerboseLogging(
      int level);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__UnmanageableVesselVelocity",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ UnmanageableVesselVelocity(
      this IntPtr plugin,
      QP degrees_of_freedom,
      int celestial_index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__UpdateCelestialHierarchy",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void UpdateCelestialHierarchy(
      this IntPtr plugin,
      int celestial_index,
      int parent_index);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__UpdatePrediction",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void UpdatePrediction(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselBinormal",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselBinormal(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselFromParent",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP VesselFromParent(
      this IntPtr plugin,
      int parent_index,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselGetPredictionAdaptiveStepParameters",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern AdaptiveStepParameters VesselGetPredictionAdaptiveStepParameters(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselNormal",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselNormal(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselSetPredictionAdaptiveStepParameters",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void VesselSetPredictionAdaptiveStepParameters(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid,
      AdaptiveStepParameters adaptive_step_parameters);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselTangent",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselTangent(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

  [DllImport(dllName           : dll_path,
             EntryPoint        = "principia__VesselVelocity",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselVelocity(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(InUTF8Marshaler))] String vessel_guid);

}

}  // namespace ksp_plugin_adapter
}  // namespace principia
