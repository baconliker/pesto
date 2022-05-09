<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" xmlns:dt="http://xsltsl.org/date-time">
	<xsl:output method="xml" indent="yes" />

	<!--
	border="1px solid black"
	-->

	<xsl:template match="/">
		<fo:root>
			<fo:layout-master-set>
				<fo:simple-page-master master-name="first-page" page-width="297mm" page-height="210mm" margin-top="5mm" margin-bottom="5mm" margin-left="5mm" margin-right="5mm">
					<fo:region-body margin-top="5mm" margin-bottom="10mm"/>
					<fo:region-after extent="5mm"/>
				</fo:simple-page-master>

				<fo:simple-page-master master-name="other-pages" page-width="297mm" page-height="210mm" margin-top="5mm" margin-bottom="5mm" margin-left="5mm" margin-right="5mm">
					<fo:region-body margin-top="10mm" margin-bottom="10mm"/>
					<fo:region-before extent="5mm"/>
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
          <fo:block font-family="Nina" font-size="9pt" font-weight="bold" color="#C0C0C0">
            <fo:table width="100%" table-layout="fixed">
              <fo:table-column column-width="50%"/>
              <fo:table-column column-width="50%"/>
              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell>
                    <fo:block>
											<xsl:value-of select="/Boris/Competition/Name"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell>
                    <fo:block text-align="right">
											Team Results
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
				</fo:static-content>

				<!-- FOOTER -->
				<fo:static-content flow-name="xsl-region-after">
					<fo:block font-family="Nina" font-size="8pt" text-align="center">
						<fo:page-number/> of <fo:page-number-citation ref-id="the-end"/>
					</fo:block>
				</fo:static-content>

				<!-- BODY -->
				<fo:flow flow-name="xsl-region-body">
					<fo:block font-family="Nina" font-size="9pt">
            <fo:block font-size="16pt" font-weight="bold">
              <xsl:value-of select="/Boris/Competition/Name"/>
            </fo:block>

            <fo:block font-size="12pt" font-weight="bold" margin-top="5mm">
              <xsl:text>Team Results - After </xsl:text>
              <xsl:value-of select="count(/Boris/Results/Class[1]/Table/Columns/Column[Type = 'S'])"/>
              <xsl:choose>
                <xsl:when test="count(/Boris/Results/Class[1]/Table/Columns/Column[Type = 'S']) = 1"> Task</xsl:when>
                <xsl:otherwise> Tasks</xsl:otherwise>
              </xsl:choose>
            </fo:block>

            <xsl:apply-templates select="/Boris/Results/Class"/>
						
						<fo:block id="the-end"/>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>

  <xsl:template match="Class">
		<fo:block font-size="11pt" font-weight="bold" margin-top="8mm">
			<xsl:value-of select="Code"/> (<xsl:value-of select="Description"/>)
		</fo:block>
		
    <fo:block font-size="{FontSize}pt">
      <fo:table width="30%" table-layout="fixed" margin-top="3mm" keep-with-previous="always">
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
                <xsl:when test="position() mod 2 = 0">#CCC0D9</xsl:when>
                <xsl:otherwise>#E5DFEC</xsl:otherwise>
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
                      <xsl:value-of select="Value"/>
                    </fo:block>
                  </fo:table-cell>
                </xsl:if>
              </xsl:for-each>
            </fo:table-row>
            <!-- SHOW TEAM MEMBERS
						<fo:table-row background-color="{$row-color}">
							<fo:table-cell>
								<fo:block></fo:block>
							</fo:table-cell>
							<fo:table-cell padding="0.5mm" number-columns-spanned="{count(../../Columns/Column) - 2}">
								<fo:block color="#3C3C3C" font-size="smaller">
									TODO: FIGURE OUT THE RIGHT 'TEAM MEMBERS' CELL PROPERLY INSTEAD OF ASSUMING ITS POSITION
									<xsl:value-of select="Cell[3]/Value"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
            -->
          </xsl:for-each>
        </fo:table-body>
      </fo:table>
    </fo:block>
  </xsl:template>
  
</xsl:stylesheet>