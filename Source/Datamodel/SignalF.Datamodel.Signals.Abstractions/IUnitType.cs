using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{

	public enum EUnitType
	{
		None,
		Acceleration,
		Angle,
		Area,
		Capacity,
		Current,
		Density,
		DynamicViscosity,
		Force,
		KinematicViscosity,
		Length,
		Loudness,
		Mass,
		MassFlowrate,
		MassFlux,
		MolarMass,
		Power,
		Pressure,
		Sensitivity,
		SpecificEnthalpy,
		SpecificVolume,
		SpecificWeight,
		Temperature,
		Time,
		Velocity,
		Voltage,
		Volume,
	}

	public partial interface IUnitType
	{

		#region Properties

		EUnitType Value{get;set;}

		EUnitType DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EUnitType value);

		#endregion Methods

	}
}

