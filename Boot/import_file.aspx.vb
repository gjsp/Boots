Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports Microsoft.Office.Interop
Partial Class import_file
    Inherits basePage
    Function saveExcel() As Boolean
        Dim xlApp As New Excel.Application
        Try
            Dim eName As String = DateTime.Now.ToString("dd-MM-yyyy") + "_" + Replace(ExceFile.FileName, " ", "_")

            Dim OpenFile As String
            'Dim i As Integer
            Dim k As Integer
            Dim kb As Integer
            Dim bb As Integer

            OpenFile = "files\excel\" + eName

            '*** Create Excel.Application ***'

            Dim xlBook As Excel.Workbook
            Dim xlSheet1 As Excel.Worksheet

            xlBook = xlApp.Workbooks.Open(Server.MapPath(OpenFile))
            xlBook.Application.Visible = False
            xlBook.Application.DisplayAlerts = False

            Dim cost_data As Data.DataTable
            cost_data = ClsDB.getCostcenter

            kb = 0

            For Each drow As Data.DataRow In cost_data.Rows

                'xlSheet1 = xlBook.Worksheets.Item("4071")
                'If drow.Item("costcenter_code") = "4071" Then
                '    Dim d As String = "555"
                'End If


                Try
                    ' xlSheet1 = xlBook.Worksheets.Item("8888")

                    xlSheet1 = xlBook.Worksheets.Item(drow.Item("costcenter_code"))
                    'Result = xlBook.Worksheets.Item("4143")

                    '*** Create DataTable ***'
                    Dim dt As New System.Data.DataTable
                    ' Dim dr As System.Data.DataRow

                    '*** Column ***'

                    k = 0

                    For j As Integer = 1 To 100
                        If xlSheet1.Cells.Item(9, j).Value Is Nothing Then
                            Exit For
                        Else
                            dt.Columns.Add("Cloumn" + j.ToString)
                            k = k + 1
                        End If
                    Next

                    bb = 0
                    bb = k - 1

                    Dim dz As Data.DataTable
                    Dim bbz As String = "1/" + Month(DateValue(xlSheet1.Cells.Item(9, bb).Value)).ToString() + "/" + Year(DateValue(xlSheet1.Cells.Item(9, bb).Value)).ToString()
                    dz = ClsDB.getMonthBydate(bbz)

                    If dz.Rows.Count > 0 And kb = 0 Then
                        ClsManage.alert(Page, "Duplicate Month Data")
                        Panel1.Visible = False
                        Return False
                    Else
                        kb = 1
                        With xlSheet1.Cells
                            ClsDB.InsertMTD(drow.Item("costcenter_id").ToString, _
.Item(clsBts.reportColumn.TotalRevenue, bb).Value, _
.Item(clsBts.reportColumn.RETAIL_TESPIncome, bb).Value, _
.Item(clsBts.reportColumn.OtherRevenue, bb).Value, _
.Item(clsBts.reportColumn.CostofGoodSold, bb).Value, _
.Item(clsBts.reportColumn.GrossProfit, bb).Value, _
.Item(clsBts.reportColumn.GrossProfit_percent, bb).Value, _
.Item(clsBts.reportColumn.MarginAdjustments, bb).Value, _
.Item(clsBts.reportColumn.Shipping, bb).Value, _
.Item(clsBts.reportColumn.StockLossandObsolescence, bb).Value, _
.Item(clsBts.reportColumn.InventoryAdjustment_stock, bb).Value, _
.Item(clsBts.reportColumn.InventoryAdjustment_damage, bb).Value, _
.Item(clsBts.reportColumn.StockLoss_Provision, bb).Value, _
.Item(clsBts.reportColumn.StockObsolescence_Provision, bb).Value, _
.Item(clsBts.reportColumn.GWP, bb).Value, _
.Item(clsBts.reportColumn.GWPs_Corporate, bb).Value, _
.Item(clsBts.reportColumn.GWPs_Transferred, bb).Value, _
.Item(clsBts.reportColumn.SellingCosts, bb).Value, _
.Item(clsBts.reportColumn.Creditcardscommission, bb).Value, _
.Item(clsBts.reportColumn.LabellingMaterial, bb).Value, _
.Item(clsBts.reportColumn.OtherIncome_COSHFunding, bb).Value, _
.Item(clsBts.reportColumn.OtherIncomeSupplier, bb).Value, _
.Item(clsBts.reportColumn.AdjustedGrossMargin, bb).Value, _
.Item(clsBts.reportColumn.SupplyChainCosts, bb).Value, _
.Item(clsBts.reportColumn.TotalStoreExpenses, bb).Value, _
.Item(clsBts.reportColumn.StoreLabourCosts, bb).Value, _
.Item(clsBts.reportColumn.GrossPay, bb).Value, _
.Item(clsBts.reportColumn.TemporaryStaffCosts, bb).Value, _
.Item(clsBts.reportColumn.Allowance, bb).Value, _
.Item(clsBts.reportColumn.Overtime, bb).Value, _
.Item(clsBts.reportColumn.Licensefee, bb).Value, _
.Item(clsBts.reportColumn.Bonuses_Incentives, bb).Value, _
.Item(clsBts.reportColumn.BootsBrandncentives, bb).Value, _
.Item(clsBts.reportColumn.SuppliersIncentive, bb).Value, _
.Item(clsBts.reportColumn.ProvidentFund, bb).Value, _
.Item(clsBts.reportColumn.PensionCosts, bb).Value, _
.Item(clsBts.reportColumn.SocialSecurityFund, bb).Value, _
.Item(clsBts.reportColumn.Uniforms, bb).Value, _
.Item(clsBts.reportColumn.EmployeeWelfare, bb).Value, _
.Item(clsBts.reportColumn.OtherBenefitsEmployee, bb).Value, _
.Item(clsBts.reportColumn.StorePropertyCosts, bb).Value, _
.Item(clsBts.reportColumn.PropertyRental, bb).Value, _
.Item(clsBts.reportColumn.PropertyServices, bb).Value, _
.Item(clsBts.reportColumn.PropertyFacility, bb).Value, _
.Item(clsBts.reportColumn.Propertytaxes, bb).Value, _
.Item(clsBts.reportColumn.Facialtaxes, bb).Value, _
.Item(clsBts.reportColumn.PropertyInsurance, bb).Value, _
.Item(clsBts.reportColumn.Signboard, bb).Value, _
.Item(clsBts.reportColumn.Discount_Rent_Services_Facility, bb).Value, _
.Item(clsBts.reportColumn.GPCommission, bb).Value, _
.Item(clsBts.reportColumn.AmortizationofLeaseRight, bb).Value, _
.Item(clsBts.reportColumn.Depreciation, bb).Value, _
.Item(clsBts.reportColumn.DepreciationofShortLeaseBuilding, bb).Value, _
.Item(clsBts.reportColumn.DepreciationofComputerHardware, bb).Value, _
.Item(clsBts.reportColumn.DepreciationofFixturesFittings, bb).Value, _
.Item(clsBts.reportColumn.DepreciationofComputerSoftware, bb).Value, _
.Item(clsBts.reportColumn.DepreciationofOfficeEquipment, bb).Value, _
.Item(clsBts.reportColumn.OtherStoreCosts, bb).Value, _
.Item(clsBts.reportColumn.ServiceChargesandOtherFees, bb).Value, _
.Item(clsBts.reportColumn.BankCharges, bb).Value, _
.Item(clsBts.reportColumn.CashCollectionCharge, bb).Value, _
.Item(clsBts.reportColumn.Cleaning, bb).Value, _
.Item(clsBts.reportColumn.SecurityGuards, bb).Value, _
.Item(clsBts.reportColumn.Carriage, bb).Value, _
.Item(clsBts.reportColumn.LicenceFees, bb).Value, _
.Item(clsBts.reportColumn.OtherServicesCharge, bb).Value, _
.Item(clsBts.reportColumn.OtherFees, bb).Value, _
.Item(clsBts.reportColumn.Utilities, bb).Value, _
.Item(clsBts.reportColumn.Water, bb).Value, _
.Item(clsBts.reportColumn.Gas_Electric, bb).Value, _
.Item(clsBts.reportColumn.AirCond_Addition, bb).Value, _
.Item(clsBts.reportColumn.RepairandMaintenance, bb).Value, _
.Item(clsBts.reportColumn.RMOther_Fix, bb).Value, _
.Item(clsBts.reportColumn.RMOther_Unplan, bb).Value, _
.Item(clsBts.reportColumn.RMComputer_Fix, bb).Value, _
.Item(clsBts.reportColumn.RMComputer_Unplan, bb).Value, _
.Item(clsBts.reportColumn.ProfessionalFee, bb).Value, _
.Item(clsBts.reportColumn.MarketingResearch, bb).Value, _
.Item(clsBts.reportColumn.OtherFee, bb).Value, _
.Item(clsBts.reportColumn.Equipment_MaterailandSupplies, bb).Value, _
.Item(clsBts.reportColumn.PrintingandStationery, bb).Value, _
.Item(clsBts.reportColumn.SuppliesExpenses, bb).Value, _
.Item(clsBts.reportColumn.Equipment, bb).Value, _
.Item(clsBts.reportColumn.Shopfitting, bb).Value, _
.Item(clsBts.reportColumn.PackagingandOtherMaterial, bb).Value, _
.Item(clsBts.reportColumn.BusinessTravelExpenses, bb).Value, _
.Item(clsBts.reportColumn.CarParkingandOthers, bb).Value, _
.Item(clsBts.reportColumn.Travel, bb).Value, _
.Item(clsBts.reportColumn.Accomodation, bb).Value, _
.Item(clsBts.reportColumn.MealandEntertainment, bb).Value, _
.Item(clsBts.reportColumn.Insurance, bb).Value, _
.Item(clsBts.reportColumn.AllRiskInsurance, bb).Value, _
.Item(clsBts.reportColumn.HealthandLifeInsurance, bb).Value, _
.Item(clsBts.reportColumn.PenaltyandTaxation, bb).Value, _
.Item(clsBts.reportColumn.Taxation, bb).Value, _
.Item(clsBts.reportColumn.Penalty, bb).Value, _
.Item(clsBts.reportColumn.OtherRelatedStaffCost, bb).Value, _
.Item(clsBts.reportColumn.StaffConferenceandTraining, bb).Value, _
.Item(clsBts.reportColumn.Training, bb).Value, _
.Item(clsBts.reportColumn.Communication, bb).Value, _
.Item(clsBts.reportColumn.TelephoneCalls_Faxes, bb).Value, _
.Item(clsBts.reportColumn.PostageandCourier, bb).Value, _
.Item(clsBts.reportColumn.OtherExpenses, bb).Value, _
.Item(clsBts.reportColumn.Sample_Tester, bb).Value, _
.Item(clsBts.reportColumn.PreopeningCosts, bb).Value, _
.Item(clsBts.reportColumn.LossonClaim, bb).Value, _
.Item(clsBts.reportColumn.CashOvertage_Shortagefromsales, bb).Value, _
.Item(clsBts.reportColumn.MiscellenousandOther, bb).Value, _
.Item(clsBts.reportColumn.StoreTradingProfit__Loss, bb).Value, _
.Item(clsBts.reportColumn.TradingProfit__Loss, bb).Value, _
.Item(clsBts.reportColumn.StoreControllableCostsforBSC, bb).Value, _
.Item(clsBts.reportColumn.StoreLabourCost, bb).Value, _
.Item(clsBts.reportColumn.Utillity, bb).Value, _
.Item(clsBts.reportColumn.RepairMaintenance, bb).Value, _
.Item(clsBts.reportColumn.SWMaintenance, bb).Value, _
.Item(clsBts.reportColumn.HWMaintenance, bb).Value, _
.Item(clsBts.reportColumn.ITTelecommunications, bb).Value, _
                                            "1/" + Month(DateValue(.Item(9, bb).Value)).ToString() + "/" + Year(DateValue(.Item(9, bb).Value)).ToString())
                        End With
                    End If

                    ' ClsDB.InsertYTD(drow.Item("costcenter_id").ToString, xlSheet1.Cells.Item(10, k).Value, xlSheet1.Cells.Item(11, k).Value, xlSheet1.Cells.Item(12, k).Value, xlSheet1.Cells.Item(13, k).Value, xlSheet1.Cells.Item(14, k).Value, xlSheet1.Cells.Item(15, k).Value, xlSheet1.Cells.Item(16, k).Value, xlSheet1.Cells.Item(17, k).Value, xlSheet1.Cells.Item(18, k).Value, xlSheet1.Cells.Item(19, k).Value, xlSheet1.Cells.Item(20, k).Value, xlSheet1.Cells.Item(21, k).Value, xlSheet1.Cells.Item(22, k).Value, xlSheet1.Cells.Item(23, k).Value, xlSheet1.Cells.Item(24, k).Value, xlSheet1.Cells.Item(25, k).Value, xlSheet1.Cells.Item(26, k).Value, xlSheet1.Cells.Item(27, k).Value, xlSheet1.Cells.Item(28, k).Value, xlSheet1.Cells.Item(29, k).Value, xlSheet1.Cells.Item(30, k).Value, xlSheet1.Cells.Item(31, k).Value, xlSheet1.Cells.Item(32, k).Value, xlSheet1.Cells.Item(33, k).Value, xlSheet1.Cells.Item(34, k).Value, xlSheet1.Cells.Item(35, k).Value, xlSheet1.Cells.Item(36, k).Value, xlSheet1.Cells.Item(37, k).Value, xlSheet1.Cells.Item(38, k).Value, xlSheet1.Cells.Item(39, k).Value, xlSheet1.Cells.Item(40, k).Value, xlSheet1.Cells.Item(41, k).Value, xlSheet1.Cells.Item(42, k).Value, xlSheet1.Cells.Item(43, k).Value, xlSheet1.Cells.Item(44, k).Value, xlSheet1.Cells.Item(45, k).Value, xlSheet1.Cells.Item(46, k).Value, xlSheet1.Cells.Item(47, k).Value, xlSheet1.Cells.Item(48, k).Value, xlSheet1.Cells.Item(49, k).Value, xlSheet1.Cells.Item(50, k).Value, xlSheet1.Cells.Item(51, k).Value, xlSheet1.Cells.Item(52, k).Value, xlSheet1.Cells.Item(53, k).Value, xlSheet1.Cells.Item(54, k).Value, xlSheet1.Cells.Item(55, k).Value, xlSheet1.Cells.Item(56, k).Value, xlSheet1.Cells.Item(57, k).Value, xlSheet1.Cells.Item(58, k).Value, xlSheet1.Cells.Item(59, k).Value, xlSheet1.Cells.Item(60, k).Value, xlSheet1.Cells.Item(61, k).Value, xlSheet1.Cells.Item(62, k).Value, xlSheet1.Cells.Item(63, k).Value, xlSheet1.Cells.Item(64, k).Value, xlSheet1.Cells.Item(65, k).Value, xlSheet1.Cells.Item(66, k).Value, xlSheet1.Cells.Item(67, k).Value, xlSheet1.Cells.Item(68, k).Value, xlSheet1.Cells.Item(69, k).Value, xlSheet1.Cells.Item(70, k).Value, xlSheet1.Cells.Item(71, k).Value, xlSheet1.Cells.Item(72, k).Value, xlSheet1.Cells.Item(73, k).Value, xlSheet1.Cells.Item(74, k).Value, xlSheet1.Cells.Item(75, k).Value, xlSheet1.Cells.Item(76, k).Value, xlSheet1.Cells.Item(77, k).Value, xlSheet1.Cells.Item(78, k).Value, xlSheet1.Cells.Item(79, k).Value, xlSheet1.Cells.Item(80, k).Value, xlSheet1.Cells.Item(81, k).Value, xlSheet1.Cells.Item(82, k).Value, xlSheet1.Cells.Item(83, k).Value, xlSheet1.Cells.Item(84, k).Value, xlSheet1.Cells.Item(85, k).Value, xlSheet1.Cells.Item(86, k).Value, xlSheet1.Cells.Item(87, k).Value, xlSheet1.Cells.Item(88, k).Value, xlSheet1.Cells.Item(89, k).Value, xlSheet1.Cells.Item(90, k).Value, xlSheet1.Cells.Item(91, k).Value, xlSheet1.Cells.Item(92, k).Value, xlSheet1.Cells.Item(93, k).Value, xlSheet1.Cells.Item(94, k).Value, xlSheet1.Cells.Item(95, k).Value, xlSheet1.Cells.Item(96, k).Value, xlSheet1.Cells.Item(97, k).Value, xlSheet1.Cells.Item(98, k).Value, xlSheet1.Cells.Item(99, k).Value, xlSheet1.Cells.Item(100, k).Value, xlSheet1.Cells.Item(101, k).Value, xlSheet1.Cells.Item(102, k).Value, xlSheet1.Cells.Item(103, k).Value, xlSheet1.Cells.Item(104, k).Value, xlSheet1.Cells.Item(105, k).Value, xlSheet1.Cells.Item(106, k).Value, xlSheet1.Cells.Item(107, k).Value, xlSheet1.Cells.Item(108, k).Value, xlSheet1.Cells.Item(109, k).Value, xlSheet1.Cells.Item(110, k).Value, xlSheet1.Cells.Item(111, k).Value, xlSheet1.Cells.Item(112, k).Value, xlSheet1.Cells.Item(113, k).Value, xlSheet1.Cells.Item(114, k).Value, xlSheet1.Cells.Item(115, k).Value, xlSheet1.Cells.Item(116, k).Value, xlSheet1.Cells.Item(117, k).Value, xlSheet1.Cells.Item(118, k).Value, xlSheet1.Cells.Item(120, k).Value, xlSheet1.Cells.Item(121, k).Value, xlSheet1.Cells.Item(122, k).Value, xlSheet1.Cells.Item(123, k).Value, xlSheet1.Cells.Item(9, bb).Value)
                    '*** Quit and Clear Object ***'
                Catch

                End Try

            

            Next

            'xlApp.Application.Quit()
            'xlApp.Quit()
            'xlSheet1 = Nothing
            'xlBook = Nothing
            'xlApp = Nothing
            Return True
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        Finally
            xlApp.Application.Quit()
            xlApp.Quit()
        End Try
    End Function
    Function saveData() As Boolean
        Try
            If ExceFile.HasFile And Not ClsDB.IsExcel(ExceFile.PostedFile.FileName) Then
                ClsManage.alert(Page, "File Only Excel")
                ExceFile.Focus()
                Return False
            End If

            Dim excelName As String = ""

            If ExceFile.HasFile Then
                excelName = DateTime.Now.ToString("dd-MM-yyyy") + "_" + Replace(ExceFile.FileName, " ", "_")
                ExceFile.SaveAs(Server.MapPath("") + "\files\excel\" + excelName)
                ClsDB.InsertLog(excelName)
            End If

        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
        Return True
    End Function
    Protected Sub SaveBt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveBt.Click
        Try
            If saveData() Then
                If saveExcel() Then
                    ClsManage.alert(Page, "Update Complete", , "import_file.aspx?mode=complete")
                End If
            End If
        Catch ex As Exception
            ClsManage.alert(Page, ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("mode") = "complete" Then
                Panel1.Visible = True
            End If
        End If
    End Sub
End Class
