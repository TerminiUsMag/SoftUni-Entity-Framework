using EFScaffoldingDemo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System;
using System.Text.Json;
using System.Xml.Linq;

using (SoftUniContext context = new SoftUniContext())
{
    var employees = await context.Employees
        .OrderByDescending(e => e.Salary)
        .Where(e => e.DepartmentId == 7)
        .Include(e => e.Department)
        .Select(e => new
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            MiddleName = e.MiddleName,
            DepartmentName = e.Department.Name,
            Salary = e.Salary
        })
        .ToListAsync();

    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary} -> {employee.DepartmentName}");
    }

    var serializedEmployees = JsonConvert.SerializeObject(employees,Formatting.Indented);
    Console.WriteLine(serializedEmployees);

    string raw = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Result>
	<Item alias=""sys_System"">
		<name>Optical System - demo 17A</name>
		<Relationships>
			<Item alias=""sys_System_Study"">
				<Relationships>
					<Item alias=""sm_Study"">
						<current_state keyed_name=""Preliminary"">7E0F0D796D504B9481CEBB9870C175E3</current_state>
						<id keyed_name=""ST-000012 V&V Study Demo 17A"">7006435B84774F23B35B1DCA8907A9C7</id>
						<state>Preliminary</state>
						<name>V&V Study Demo 17A</name>
						<Relationships>
							<Item alias=""sm_Study_ProcessElement"">
								<Relationships>
									<Item alias=""sm_Task"">
										<id keyed_name=""SIM-000232 Use case 3 - demo 17A"">CDE87335A4DD4D43AEF23D84B3F141FB</id>
										<keyed_name>SIM-000232 Use case 3 - demo 17A</keyed_name>
										<state>Submitted</state>
										<name>Use case 3 - demo 17A</name>
										<Relationships>
											<Item alias=""ar_SimulationResult"">
												<ar_resultname>Encircled Energy</ar_resultname>
												<ar_resultunit>not defined</ar_resultunit>
												<ar_resultvalue>0.36258037</ar_resultvalue>
												<ar_target_met>NO</ar_target_met>
												<Relationships>
													<Item alias=""re_Requirement"">
														<ar_conditionexp> val > 0.40 </ar_conditionexp>
														<id keyed_name=""REQ-000000012 Encircled Energy Cond2"">82530FBC50744FA5A6BAA42C3DBDCC06</id>
														<keyed_name>REQ-000000012 Encircled Energy Cond2</keyed_name>
														<req_title>Encircled Energy Cond2</req_title>
													</Item>
												</Relationships>
											</Item>
											<Item alias=""sm_Task DesignRepresentation"">
												<Relationships>
													<Item alias=""sm_DesignRepresentation"">
														<id keyed_name=""Optical System 1"">9F48FAE962C148DDB0D6B56095D41EDB</id>
														<itemtype>F09A89AEF0F74FA8BD5ED2F822C0E9A7</itemtype>
														<keyed_name>Optical System 1</keyed_name>
														<state>Released</state>
													</Item>
												</Relationships>
											</Item>
											<Item alias=""ar_EnvironmentRepresentations"">
												<Relationships>
													<Item alias=""ar_envRep_edcs"">
														<id keyed_name=""WVL 1 1"">238C18C317F94ADDA65A6074C1B98104</id>
														<keyed_name>WVL 1 1</keyed_name>
														<state>Closed</state>
													</Item>
												</Relationships>
											</Item>
										</Relationships>
									</Item>
								</Relationships>
							</Item>
							<Item alias=""sys_SystemElement Structure"">
								<Relationships>
									<Item alias=""sys_SystemElement"">
										<id keyed_name=""Mirror1 1"">C3487A09DE06437F9A2050C9AEA2CE4D</id>
										<keyed_name>Mirror1 1</keyed_name>
										<name>Mirror1</name>
										<Relationships>
											<Item alias=""ar_SystemElement_PolyEDC"">
												<Relationships>
													<Item alias=""ar_PolyEDC"">
														<name>Surface 1</name>
													</Item>
												</Relationships>
											</Item>
											<Item alias=""ar_SystemElement_PolyEDC"">
												<Relationships>
													<Item alias=""ar_PolyEDC"">
														<name>Surface Offset 1</name>
													</Item>
												</Relationships>
											</Item>
											<Item alias=""sys_Requirement_SysElem"">
												<id keyed_name=""1CB7975079AA472A8E1B380FA808AE8F"">1CB7975079AA472A8E1B380FA808AE8F</id>
												<Relationships>
													<Item alias=""re_Requirement_SysElem"">
														<ar_conditionexp> val > 0.25 </ar_conditionexp>
														<id keyed_name=""REQ-000000011 Encircled Energy Cond1"">ACCBE42777634ABE88300C165CF8E321</id>
														<keyed_name>REQ-000000011 Encircled Energy Cond1</keyed_name>
														<item_number>REQ-000000011</item_number>
														<req_title>Encircled Energy Cond1</req_title>
													</Item>
												</Relationships>
											</Item>
										</Relationships>
									</Item>
								</Relationships>
							</Item>
						</Relationships>
					</Item>
				</Relationships>
			</Item>
		</Relationships>
	</Item>
</Result>";

    var xml = XDocument.Parse(raw);
	var result = xml.Root!.Elements();
    
}