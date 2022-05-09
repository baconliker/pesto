<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:str="http://xsltsl.org/string">
  <xsl:import href="Libraries/string.xsl"/>
  
  <xsl:output method="xml" indent="yes"/>

  <xsl:template name="header">
    <fo:block>
      <!--<fo:external-graphic src="Resources/Xsl/Banner.png" width="289mm" height="30.8mm" content-width="scale-to-fit" content-height="scale-to-fit"/>-->
      <fo:table width="100%" table-layout="fixed">
        <fo:table-column column-width="70%"/>
        <fo:table-column column-width="30%"/>
        <fo:table-body>
          <fo:table-row>
            <fo:table-cell>
              <fo:block>
                <fo:external-graphic src="Resources/Xsl/BritishOpenLogo.png" width="72.8mm" height="28.9mm" content-width="scale-to-fit" content-height="scale-to-fit"/>
              </fo:block>
            </fo:table-cell>
            <fo:table-cell>
              <fo:block font-size="20pt" font-weight="bold" text-align="right" margin-top="2mm">
                <xsl:value-of select="/Boris/Competition/Name"/>
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
