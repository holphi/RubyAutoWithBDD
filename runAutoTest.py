copyright = '''COPYRIGHT: (C) 2015 Dolby Laboratories,. All rights reserved.
Author: Alex LI
'''

import sys
import os, stat

from os.path import join, abspath, exists, isfile
from subprocess import call, Popen

#Clear environment
def clearEnv():
    #Remove test result in last test execution
    xml_result = abspath(join('.', 'TestResult.xml'))
    if exists(xml_result):
        os.remove(xml_result)
    html_result = abspath(join('.', 'AndroidTestReport.html'))
    if exists(html_result):
        os.remove(html_result)

#Build QA Test Project
def buildQATestProject():
    call(['msbuild', 'RubyAndroidPlayerTest.sln'], shell=True)

#Execute NUnit Test:
def execQATest():
    call(['nunit-console', '/xml=TestResult.xml', './RubyAndroidPlayerTest/bin/Debug/RubyAndroidPlayerTest.dll'], shell=True)

#Run Specflow executable to generate HTML report
def generateHTMLRpt():
	cmd = join('.', 'packages', 'SpecFlow.1.9.0', 'tools', 'specflow.exe')
	p = Popen(cmd+ ' nunitexecutionreport .\RubyAndroidPlayerTest\RubyAndroidPlayerTest.csproj /out:AndroidTestReport.html')
	p.communicate()
	
#Main entry
def main():
    try:
        print copyright
        #Clear environment
        clearEnv()
        #Build QA Test Project
        buildQATestProject()
        #Execute QA Test
        execQATest()
        #Generate html report
        generateHTMLRpt()
    except Exception, e:
        raise e

if __name__=='__main__':
    main()