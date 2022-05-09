<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output method="xml" indent="yes" />

	<xsl:template match="/">
		<fo:root>
			<fo:layout-master-set>
				<fo:simple-page-master master-name="first-page" page-width="297mm" page-height="210mm" margin-top="5mm" margin-bottom="5mm" margin-left="5mm" margin-right="5mm">
					<fo:region-body margin-top="5mm" margin-bottom="10mm"/>
				</fo:simple-page-master>

				<fo:simple-page-master master-name="other-pages" page-width="297mm" page-height="210mm" margin-top="5mm" margin-bottom="5mm" margin-left="5mm" margin-right="5mm">
					<fo:region-body margin-top="10mm" margin-bottom="10mm"/>
				</fo:simple-page-master>

				<fo:page-sequence-master master-name="document-sequence">
					<fo:single-page-master-reference master-reference="first-page"/>
					<fo:repeatable-page-master-reference master-reference="other-pages"/>
				</fo:page-sequence-master>
			</fo:layout-master-set>

			<fo:page-sequence master-reference="document-sequence">
				<fo:flow flow-name="xsl-region-body">
					<fo:block>
            <xsl:value-of select="/InputDocument/Message"/>
					</fo:block>
				</fo:flow>
			</fo:page-sequence>
		</fo:root>
	</xsl:template>
  
</xsl:stylesheet>