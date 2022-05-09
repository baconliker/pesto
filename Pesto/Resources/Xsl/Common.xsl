<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
  <xsl:output method="xml" indent="yes" />

  <xsl:param name="odd-color"/>
  <xsl:param name="even-color"/>
  
  <!--
	border="1px solid black"
	-->

  <xsl:template match="Class">
    <fo:block font-size="11pt" font-weight="bold" margin-top="8mm">
      <xsl:value-of select="$odd-color"/> (<xsl:value-of select="Description"/>)
    </fo:block>

    <fo:block font-size="{FontSize}pt">
      <fo:table width="30%" table-layout="fixed" margin-top="5mm" keep-with-previous="always">
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

              <fo:table-cell padding="0.5mm" display-align="after">
                <fo:block text-align="{$cell-align}">
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
                <xsl:when test="position() mod 2 = 0">
                  <xsl:value-of select="$odd-color"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="$even-color"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>

            <fo:table-row background-color="#{$row-color}">
              <xsl:for-each select="Cell">
                <xsl:variable name="cell-number" select="position()"/>
                <xsl:variable name="cell-align">
                  <xsl:choose>
                    <xsl:when test="../../../Columns/Column[$cell-number]/Align = 'C'">center</xsl:when>
                    <xsl:when test="../../../Columns/Column[$cell-number]/Align = 'R'">right</xsl:when>
                    <xsl:otherwise>left</xsl:otherwise>
                  </xsl:choose>
                </xsl:variable>

                <xsl:if test="../../../Columns/Column[$cell-number]/Visible = 'Y'">
                  <fo:table-cell text-align="{$cell-align}" padding="0.5mm">
                    <fo:block>
                      <xsl:value-of select="Value"/>
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