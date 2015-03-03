<?xml version="1.0" encoding="iso-8859-1"?>
<!--Special for GA-->

<!--Care Coordinator
* Consumer Search
* Provider Application
* Provider Search
* Invoice
* Timesheets
* Reporting
* Manage Users
* Contact Us


CME Supervisor
* Care Coordinator Search
* Consumer Search
* Provider Search
* Timesheets
* Manage Users
* Contact Us


Provider Invoice
* Invoice
* Contact Us


Waiver Coordinator
* Authorization Approval
* Consumer Search
* Provider Search
* Reporting
* Contact Us


PPL Admin
* Email Notification
* Consumer Search
* Provider Application
* Provider Search
* Invoice
* Timesheets
* Timesheet List
* Support Tickets
* Manage Users
* Contact Us-->




<xsl:stylesheet version="1.0"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
	<xsl:template match="/">

		<html>
			<head>
				<title>test result _ GA</title>
				<style type="text/css">
					body{
					<!--background-image:url(ReportStyle\title.jpg);-->
					background-color:#ffffff;
					font-family:Verdana,Candara,Arial;
					}
					table {
					border: 1px solid #CCCCCC;
					border-collapse: collapse;
					}
					tr,td{
					height:30px;
					font-size:12px;
					border-collapse: collapse;
					}
					h2{
					padding-left:20px;
					color:#ff0000
					font-size:14px;
					}
					th
					{
					background-color:#CCcccC ;
					font-size:14px;
					}

					.a{
					cursor:hand;
					}
					fieldset{
					border:1px solid #6699CC ;
					}
					legend {
					color:#005aa7;
					font-weight:  bolder;
					font-size:14px;
					}

					.Clegend {
					color:#cc0000;
					font-weight:  bolder;
					font-size:16px;
					}

					.title
					{
					height:130px;
					background-color:#669999;
					background-repeat:no-repeat;
					background-image:url(ReportStyle\title.jpg);
					}
					.mydiv
					{
					height:28px;
					width:100px;
					cursor:pointer;
					border-left: 1px solid #CCCCCC;
					border-collapse: collapse;
					text-align:center;
					font-size:13px;
					font-weight:bold;
					}
					.roleDiv
					{
					margin:12px;
					height:auto;
					clear:both;
					}
				</style>
			</head>

			<body>
				<div style="height:20px;"></div>
				<br/>
				<h2>Test Report</h2>

				<br/>
				<fieldset>
					<legend>- Environment -</legend>
					<table width="1200" frame="box" style="margin:5px">
						<tr >
							<td width="150" style="background-color:#CCCCCC">OS</td>
							<td width="350">
								<xsl:value-of select="/test-results/environment/@os-version"/>
							</td>
							<td width="150" style="background-color:#CCCCCC">Platform</td>
							<td width="150">
								<xsl:value-of select="/test-results/environment/@platform"/>
							</td>
							<td width="150" style="background-color:#CCCCCC">Local</td>
							<td width="150">
								<xsl:value-of select="/test-results/culture-info/@current-uiculture"/>
							</td>
						</tr>
						<tr>
							<td style="background-color:#CCCCCC">.NET Rramework</td>
							<td>
								<xsl:value-of select="/test-results/environment/@clr-version"/>
							</td>
							<td style="background-color:#CCCCCC">Nunit</td>
							<td>
								<xsl:value-of select="/test-results/environment/@nunit-version"/>
							</td>
							<td style="background-color:#CCCCCC">Machine</td>
							<td>
								<xsl:value-of select="/test-results/environment/@machine-name"/>
							</td>
						</tr>
					</table>
				</fieldset>

				<br/>
				<fieldset>
					<legend>-Summary- </legend>
					<table width="1200px" frame="box" style="margin:5px;">
						<tr>
							<td  width="100" style="background-color:#CCCCCC">StartTime</td>
							<td  width="300">
								<xsl:value-of select="/test-results/@Time"/>
							</td>
							<td  width="100" style="background-color:#CCCCCC">EndTime</td>
							<td  width="300">
								<xsl:value-of select="/test-results/@AllEndTime"/>
							</td>
							<td  width="100" style="background-color:#CCCCCC">Total_Int</td>
							<td  width="150">
								<xsl:value-of select="/test-results/@Total"/>
							</td>
							<td  width="100" style="background-color:#CCCCCC">Total cases</td>
							<td  width="150">
								<!--<xsl:value-of select="/test-results/@ignored"/>-->
								<xsl:value-of   select="count(//test-case)"/>
							</td>
							<td  width="100" style="background-color:#CCCCCC">Succeed cases</td>
							<td  width="150">
								<xsl:value-of   select="count(//test-case[@result='Succeed'])"/>
							</td>
						</tr>
					</table>
				</fieldset>

				<br/>
				<br/>

				<fieldset>
					<legend class="Clegend">-Role: PPL Admin</legend>
					<div id="MyPannel_Role1" class="roleDiv">
						<table id="MyTitle_Role1">
							<tr >
								<td >
									<div  class="mydiv" onclick="return showPane('Consumer_PPLAdmin','MyTitle_Role1', this)" id="defaultTab_Role1">
										Consumer Search
									</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('Invoice_PPLAdmin','MyTitle_Role1', this)">Invoice</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('Timesheets_PPLAdmin','MyTitle_Role1', this)">Timesheets</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('TimesheetList_PPLAdmin','MyTitle_Role1', this)">Timesheet List</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('SupportTickets_PPLAdmin','MyTitle_Role1', this)">Support Tickets</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('ManageUsers_PPLAdmin','MyTitle_Role1', this)">Manage Users</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('ProvideApplication_PPLAdmin','MyTitle_Role1', this)">Provider Application</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('ProvideSearch_PPLAdmin','MyTitle_Role1', this)">Provider Search</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('AuthorizationApproval_PPLAdmin','MyTitle_Role1', this)">Authorization Approval</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('CareConsultantSearch_PPLAdmin','MyTitle_Role1', this)">Care Consultant Search</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('Reporting_PPLAdmin','MyTitle_Role1', this)">Reporting</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('ContactUs_PPLAdmin','MyTitle_Role1', this)">Contact Us</div>
								</td>
								<td>
									<div  class="mydiv" onclick="return showPane('EmailNotification_PPLAdmin','MyTitle_Role1', this)">Email Notification</div>
								</td>

							</tr>
						</table>
						<div  id="allFrames_Role1" style="border:0px solid #cfcfcf;width:1250px;" >
							<div id="Consumer_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Consumer']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="Invoice_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Invoice']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="Timesheets_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Timesheets']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="TimesheetList_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Timesheet List']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="SupportTickets_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Support Tickets']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="ManageUsers_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Manage Users']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="ProvideApplication_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Provider Application']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="ProvideSearch_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Provider Search']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="AuthorizationApproval_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Authorization Approval']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="CareConsultantSearch_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Care Consultant Search']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>

							</div>
							<div id="Reporting_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Reporting']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>
							<div id="ContactUs_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Contact Us']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>



							<div id="EmailNotification_PPLAdmin">
								<xsl:for-each select="test-results/test-suite">
									<xsl:if test="@Int_Role[.='PPL Admin']">
										<xsl:if test="@Int_MenuName[.='Email Notification']">
											<xsl:call-template name="IntegrationDeatil"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</div>

						</div>
					</div>
				</fieldset>
				<br/>

				<br />
				<p >
					<h3 style="font-size:14px;">Remark about the CheckPoint type:</h3>
					<ol style="font-size:12px;">
						<li>Url:          Check whether the location is correct !</li>
						<li>Title:       Check whether the browser  title is the page title you want !</li>
						<li>Table:     Check whether the cell value is correct ! </li>
						<li>Value:     Check whether the value of the element is the expected value!</li>
						<li>Object:   Check whether the element is editable/visible or not !</li>
						<li>Format: Check whether the element is present in the correct format that you expected it to be ! </li>
					</ol>
				</p>
				<script type="text/javascript" src="ReportStyle\jquery-1.4.3.js"></script>
				<script type="text/javascript" src="ReportStyle\add.js"></script>
			</body>
		</html>
	</xsl:template>

	<xsl:template name="IntegrationDeatil">
		<fieldset>
			<div >
				<u>
					<xsl:attribute name="id">
						<!--<xsl:eval>addHead()</xsl:eval>-->
					</xsl:attribute>
					<legend class="a">
						<input type="hidden" name="count">
							<xsl:attribute name="value">
								<!--<xsl:eval>addCount()</xsl:eval>-->
							</xsl:attribute>
						</input>
						-<xsl:value-of select="@Int_Name"/>   ------(total:<xsl:value-of select="@TotalStep"/>/suc: <xsl:value-of select="@succeedNum"/>)  -
					</legend>
				</u>
				<div style="margin-left:20px;margin-top:10px; ">
					Description:<xsl:value-of select="@Int_Description"/>
				</div>
			</div>
			<div style="display:none">
				<xsl:attribute name="id">
					<!--<xsl:eval>addBody()</xsl:eval>-->
				</xsl:attribute>
				<table width="1200" frame="box" style="margin:5px;" >
					<xsl:attribute name="id">
						<!--<xsl:eval>addTable()</xsl:eval>-->
					</xsl:attribute>
					<tr>
						<th width="30">Step</th>
						<th width="250">StepDescription</th>
						<th width="150">Action</th>
						<th width="50">Time</th>
						<th width="50">Result</th>
						<th>
							<table cellpadding="0" cellspacing="0" width="920" style="border:0" frame="border">
								<tr>
									<td style="font-size:16px;color:#ff0000;font-weight:  bolder;font-size:14px;" align="center"  colspan="6" >
										CheckPoint
									</td>
								</tr>
								<tr>
									<td  align="center"   width="142" style="background-color:#CCCCCC;">
										<b>
											Description
										</b>
									</td>
									<td  align="center"   width="50" style="background-color:#CCCCCC">
										<b>Type</b>
									</td>
									<td  align="center"   width="250" style="background-color:#CCCCCC">
										<b>Expected Value</b>
									</td>
									<td  align="center"   width="250" style="background-color:#CCCCCC">
										<b>Got Value</b>
									</td>
									<td  align="center"   width="50" style="background-color:#CCCCCC">
										<b>Result</b>
									</td>
									<td   width="170" align="center" style="background-color:#CCCCCC">
										<b>ScreenShot</b>
									</td>
								</tr>
							</table>
						</th>
					</tr>
					<xsl:for-each select="test-case">
						<tr>
							<td align="center">
								<xsl:value-of select="@ID"/>
							</td>
							<td align="left">
								<table  cellpadding="0" cellspacing="0" width="100%"  height="100%" style="border:0;margin:-1px" frame="border" >
									<xsl:for-each select="StepDescription">
										<tr>
											<td style="border:1 solid #CCCCCC;margin:-1px">
												<xsl:value-of select="@StepDes"/>
											</td>
										</tr>
									</xsl:for-each>
								</table>
							</td>
							<td align="left">
								<xsl:choose>
									<xsl:when test="@CaseDescription">
										<xsl:value-of select="@CaseDescription"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:value-of select="@Name"/>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td align="center" >
								<xsl:value-of select="@time"/>
								<span style="color:#ff3322">s</span>
							</td>
							<td align="center">
								<xsl:choose>
									<xsl:when test="@result">
										<xsl:if test="@result[.='Succeed']">
											<xsl:value-of select="@result"/>
										</xsl:if>
										<xsl:if test="@result[.='Failed']">
											<font style="color:red">
												<xsl:value-of select="@result"/>
											</font>
										</xsl:if>
										<xsl:if test="@result[.='Error']">
											<font style="color:red">
												<xsl:value-of select="@result"/>
											</font>
										</xsl:if>
									</xsl:when>
									<xsl:otherwise>
										<font style="color:red">
											Running Error
										</font>
									</xsl:otherwise>
								</xsl:choose>
							</td>
							<td>
								<xsl:choose>
									<xsl:when test="@result">
										<xsl:if test="@result[.='Error']">
											<span style="color:#ff0000; font-size:12px;">
												Some error take place in the website because of:
												<br/>
												<div style="margin-left:10px">
													<xsl:value-of select="@ScriptError"/>
												</div>
											</span>
										</xsl:if>
										<xsl:if test="Assert">
											<table cellpadding="0" cellspacing="0" width="100%"  height="100%" style="border:0;margin:-1px" frame="border" >
												<xsl:for-each select="Assert">
													<tr align="left">
														<td width="150" >
															<xsl:value-of select="@assert_Description"/>
														</td>
														<td align="center" width="50" >
															<xsl:value-of select="@assert_Type"/>
														</td>
														<td width="250">
															<div name="autoScroll" style="width:250px; word-break:break-all">
																<xsl:value-of select="@ value_Expected"/>
															</div>
														</td>
														<td width="250" >
															<div style="word-break:break-all;width:250px;">
																<xsl:value-of select="@value_Got"/>
															</div>
														</td>
														<td align="center" width="50">
															<xsl:if test="@result[.='Failed']">
																<font style="color:red">
																	<xsl:value-of select="@result"/>
																</font>
															</xsl:if>
															<xsl:if test="@result[.='Passed']">
																<xsl:value-of select="@result"/>
															</xsl:if>
														</td>
														<td align="center"   width="170">
															<div style="word-break:break-all;width:170px;">
																<xsl:choose>
																	<xsl:when test="@ScreenShot[.='No-Img']">
																		<xsl:value-of select="@ScreenShot"/>
																	</xsl:when>
																	<xsl:otherwise>
																		<a  target="_blank">
																			<xsl:attribute name="href">
																				<xsl:value-of select="@ScreenShot"/>
																			</xsl:attribute>
																			View Error Image
																		</a>
																	</xsl:otherwise>
																</xsl:choose>
															</div>
														</td>
													</tr>
												</xsl:for-each>
											</table>
										</xsl:if>
									</xsl:when>
									<xsl:otherwise>
										<span style="color:#ff0000;font-size:12px;">
											Test was blocked because of the error taked place in last step !
										</span>
									</xsl:otherwise>
								</xsl:choose>

							</td>
						</tr>
					</xsl:for-each>
				</table>
			</div>
			<br/>
		</fieldset>
	</xsl:template>


</xsl:stylesheet>

