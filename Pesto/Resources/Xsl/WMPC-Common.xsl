<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:str="http://xsltsl.org/string">
  <xsl:import href="Libraries/string.xsl"/>
  
  <xsl:output method="xml" indent="yes"/>

  <xsl:template name="header">
    <fo:block font-family="Tahoma">
      <fo:table width="100%" table-layout="fixed">
        <fo:table-column column-width="36mm"/>
        <fo:table-column column-width="proportional-column-width(1)"/>
        <fo:table-column column-width="25mm"/>
        <fo:table-column column-width="23mm"/>
        <fo:table-body>
          <fo:table-row>
            <fo:table-cell>
              <fo:block>
                <fo:external-graphic src="Resources/Xsl/WMPCLogo.png" width="35.5mm" height="14.0mm" content-width="scale-to-fit" content-height="scale-to-fit"/>
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block font-size="12pt" font-weight="bold" text-align="center" margin-top="3mm">9th FAI World Paramotor Championships</fo:block>
              <fo:block font-size="10pt" text-align="center">Popham Airfield, August 20th - 27th 2016</fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block>
                <fo:external-graphic src="Resources/Xsl/BMAALogo.png" width="22.5mm" height="14.0mm" content-width="scale-to-fit" content-height="scale-to-fit"/>
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block>
                <fo:external-graphic src="Resources/Xsl/CIMALogo.png" width="22.8mm" height="14.0mm" content-width="scale-to-fit" content-height="scale-to-fit"/>
              </fo:block>
            </fo:table-cell>
          </fo:table-row>
        </fo:table-body>
      </fo:table>
    </fo:block>
  </xsl:template>

  <xsl:template name="pad-pilot-number">
    <xsl:param name="pilot-number"/>

    <xsl:call-template name="str:generate-string">
      <xsl:with-param name="text" select="0"/>
      <xsl:with-param name="count" select="3 - string-length($pilot-number)"/>
    </xsl:call-template>
    <xsl:value-of select="$pilot-number"/>
  </xsl:template>
  
</xsl:stylesheet>
