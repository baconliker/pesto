<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:dt="http://xsltsl.org/date-time">
  <xsl:import href="Libraries/date-time.xsl"/>
  <xsl:import href="Results-Common.xsl"/>
  
	<xsl:output method="xml" indent="yes" />

	<!--
	border="1px solid black"
	-->

	<xsl:template match="/">
		<fo:root>
			<fo:layout-master-set>
				<fo:simple-page-master master-name="first-page" page-width="297mm" page-height="210mm" margin-top="5mm" margin-bottom="5mm" margin-left="5mm" margin-right="5mm">
					<fo:region-body margin-top="35mm" margin-bottom="10mm"/>
          <fo:region-before extent="30mm"/>
					<fo:region-after extent="5mm"/>
				</fo:simple-page-master>

				<fo:simple-page-master master-name="other-pages" page-width="297mm" page-height="210mm" margin-top="5mm" margin-bottom="5mm" margin-left="5mm" margin-right="5mm">
					<fo:region-body margin-top="5mm" margin-bottom="10mm"/>
					<fo:region-after extent="5mm"/>
				</fo:simple-page-master>

				<fo:page-sequence-master master-name="document-sequence">
					<fo:single-page-master-reference master-reference="first-page"/>
					<fo:repeatable-page-master-reference master-reference="other-pages"/>
				</fo:page-sequence-master>
			</fo:layout-master-set>

			<fo:page-sequence master-reference="document-sequence">
				<!-- HEADER -->
				<fo:static-content flow-name="xsl-region-before">
          <xsl:call-template name="header"/>
				</fo:static-content>

				<!-- FOOTER -->
				<fo:static-content flow-name="xsl-region-after">
					<fo:block font-family="Tahoma" font-size="8pt" text-align="center">
						<fo:page-number/> of <fo:page-number-citation ref-id="the-end"/>
					</fo:block>
				</fo:static-content>

				<!-- BODY -->
				<fo:flow flow-name="xsl-region-body">
					<fo:block font-family="Tahoma" font-size="9pt">
            <fo:table width="100%" table-layout="fixed">
              <fo:table-column column-width="70%"/>
              <fo:table-column column-width="30%"/>
              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell>
                    <fo:block font-size="16pt" font-weight="bold">
                      <xsl:text>Task </xsl:text>
                      <xsl:value-of select="/Boris/Task/Number"/>
                      <xsl:text> - </xsl:text>
                      <xsl:value-of select="/Boris/Task/Name"/>
                    </fo:block>
                    <fo:block font-size="8pt" font-weight="bold">
                      <xsl:call-template name="dt:format-date-time">
                        <xsl:with-param name="xsd-date-time" select="/Boris/Task/Start"/>
                        <xsl:with-param name="format">%e</xsl:with-param>
                      </xsl:call-template>
                      <xsl:text> </xsl:text>
                      <xsl:call-template name="dt:format-date-time">
                        <xsl:with-param name="xsd-date-time" select="/Boris/Task/Start"/>
                        <xsl:with-param name="format">%B %Y</xsl:with-param>
                      </xsl:call-template>
                      <xsl:text> (</xsl:text>
                      <xsl:call-template name="dt:format-date-time">
                        <xsl:with-param name="xsd-date-time" select="/Boris/Task/Start"/>
                        <xsl:with-param name="format">%A</xsl:with-param>
                      </xsl:call-template>
                      <xsl:text>)</xsl:text>
                    </fo:block>
                    <fo:block font-size="14pt" font-weight="bold">
                      <xsl:value-of select="/Boris/Results/Class[1]/Code"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell>
                    <fo:table width="100%" table-layout="fixed">
                      <fo:table-column column-width="40%"/>
                      <fo:table-column column-width="60%"/>
                      <fo:table-body>
                        <fo:table-row>
                          <fo:table-cell background-color="#E6E6E6" padding="0.5mm" border="1px solid black">
                            <fo:block>Status</fo:block>
                          </fo:table-cell>
                          <fo:table-cell padding="0.5mm" border="1px solid black">
                            <fo:block>
                              <xsl:choose>
                                <xsl:when test="/Boris/Results/Status = 'I'">Interim</xsl:when>
                                <xsl:when test="/Boris/Results/Status = 'P'">Provisional</xsl:when>
                                <xsl:when test="/Boris/Results/Status = 'O'">Official</xsl:when>
                                <xsl:when test="/Boris/Results/Status = 'F'">Final</xsl:when>
                                <xsl:when test="/Boris/Results/Status = 'C'">Cancelled</xsl:when>
                              </xsl:choose>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                        <fo:table-row>
                          <fo:table-cell background-color="#E6E6E6" padding="0.5mm" border="1px solid black">
                            <fo:block>Issued</fo:block>
                          </fo:table-cell>
                          <fo:table-cell padding="0.5mm" border="1px solid black">
                            <fo:block>
                              <xsl:call-template name="dt:format-date-time">
                                <xsl:with-param name="xsd-date-time" select="/Boris/Results/Published"/>
                                <xsl:with-param name="format">%d %B %Y %H:%M</xsl:with-param>
                              </xsl:call-template>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                        <xsl:if test="/Boris/Results/Deadline">
                          <fo:table-row>
                            <fo:table-cell background-color="#E6E6E6" padding="0.5mm" border="1px solid black">
                              <fo:block>
                                <xsl:choose>
                                  <xsl:when test="/Boris/Results/Status = 'P'">Complaint Deadline</xsl:when>
                                  <xsl:when test="/Boris/Results/Status = 'O'">Protest Deadline</xsl:when>
                                </xsl:choose>
                              </fo:block>
                            </fo:table-cell>
                            <fo:table-cell padding="0.5mm" border="1px solid black">
                              <fo:block>
                                <xsl:call-template name="dt:format-date-time">
                                  <xsl:with-param name="xsd-date-time" select="/Boris/Results/Deadline"/>
                                  <xsl:with-param name="format">%d %B %Y %H:%M</xsl:with-param>
                                </xsl:call-template>
                              </fo:block>
                            </fo:table-cell>
                          </fo:table-row>
                        </xsl:if>
                      </fo:table-body>
                    </fo:table>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>

						<xsl:apply-templates select="/Boris/Results/Class"/>
						
						<fo:block id="the-end"/>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>

	<xsl:template match="Class">
    <fo:block font-size="{FontSize}pt" margin-top="7mm">
		  <fo:table width="30%" table-layout="fixed" keep-with-previous="always">
			  <xsl:for-each select="Table/Columns/Column[Visible = 'Y']">
          <fo:table-column column-width="{Width}mm"/>
			  </xsl:for-each>
			  <fo:table-header>
				  <fo:table-row>
					  <xsl:for-each select="Table/Columns/Column[Visible = 'Y']">
              <xsl:variable name="cell-align">
                <xsl:choose>
                  <xsl:when test="Align = 'C'">center</xsl:when>
                  <xsl:when test="Align = 'R'">right</xsl:when>
                  <xsl:otherwise>left</xsl:otherwise>
                </xsl:choose>
              </xsl:variable>
              <xsl:variable name="cell-bold">
                <xsl:choose>
                  <xsl:when test="Bold = 'Y'">bold</xsl:when>
                  <xsl:otherwise>normal</xsl:otherwise>
                </xsl:choose>
              </xsl:variable>
              
						  <fo:table-cell padding="0.5mm" display-align="after">
							  <fo:block text-align="{$cell-align}" font-weight="{$cell-bold}" linefeed-treatment="preserve">
								  <xsl:value-of select="DisplayName"/>
							  </fo:block>
						  </fo:table-cell>
					  </xsl:for-each>
				  </fo:table-row>
			  </fo:table-header>
        <fo:table-body>
          <xsl:for-each select="Table/Rows/Row">
            <xsl:variable name="row-color">
              <xsl:choose>
                <xsl:when test="position() mod 2 = 0">#D8D8D8</xsl:when>
                <xsl:otherwise>#E6E6E6</xsl:otherwise>
              </xsl:choose>
            </xsl:variable>

            <fo:table-row background-color="{$row-color}">
              <xsl:for-each select="Cell">
                <xsl:variable name="cell-number" select="position()"/>
                <xsl:variable name="cell-align">
                  <xsl:choose>
                    <xsl:when test="../../../Columns/Column[$cell-number]/Align = 'C'">center</xsl:when>
                    <xsl:when test="../../../Columns/Column[$cell-number]/Align = 'R'">right</xsl:when>
                    <xsl:otherwise>left</xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>
                <xsl:variable name="cell-bold">
                  <xsl:choose>
                    <xsl:when test="../../../Columns/Column[$cell-number]/Bold = 'Y'">bold</xsl:when>
                    <xsl:otherwise>normal</xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>
                
                <xsl:if test="../../../Columns/Column[$cell-number]/Visible = 'Y'">
                  <fo:table-cell text-align="{$cell-align}" padding="0.5mm">
                    <fo:block font-weight="{$cell-bold}">
                      <xsl:choose>
                        <xsl:when test="../../../Columns/Column[$cell-number]/Type = 'N'">
                          <xsl:call-template name="pad-pilot-number">
                            <xsl:with-param name="pilot-number" select="Value"/>
                          </xsl:call-template>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="Value"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </fo:block>
                  </fo:table-cell>
                </xsl:if>
              </xsl:for-each>
            </fo:table-row>
          </xsl:for-each>
        </fo:table-body>
		  </fo:table>
    </fo:block>
	</xsl:template>
  
</xsl:stylesheet>