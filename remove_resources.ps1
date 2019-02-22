param([string]$resourceGroupName, [string]$resourceTypes = "Microsoft.Sql|Microsoft.Web")
  
$global:res = $null

Function Get-All-AzRes {
    $global:res=((Get-AzResource -ResourceGroupName $resourceGroupName) | where-object {$_.ResourceType -Match $resourceTypes})
} 

Get-All-AzRes
while($global:res){
    $global:res | Remove-AzResource -Force
    Get-All-AzRes
}