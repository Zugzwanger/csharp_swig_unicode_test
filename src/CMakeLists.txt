cmake_minimum_required(VERSION 3.13)
project(csharp_swig_unicode_test CXX)

cmake_policy(SET CMP0078 NEW)
find_package(SWIG 4.0 REQUIRED)
include(${SWIG_USE_FILE})

set(CS_DIR "${CMAKE_CURRENT_BINARY_DIR}/cs")
set(ASSEMBLY_TITLE csharp_api)

set_source_files_properties(csharp_api.i PROPERTIES CPLUSPLUS ON)

include_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}
)

configure_file(
    "${CMAKE_CURRENT_SOURCE_DIR}/test_api.csproj.in"
    "${CS_DIR}/test_api.csproj"
)

swig_add_library(test_api
    TYPE SHARED
    LANGUAGE csharp
    SOURCES csharp_api.i copy_string.cpp copy_string.h
    OUTPUT_DIR "${CS_DIR}"
)

add_custom_command(
    TARGET test_api
    PRE_BUILD
    COMMAND
        "${CMAKE_MAKE_PROGRAM}" /t:restore
    WORKING_DIRECTORY "${CS_DIR}"
)

add_custom_command(
    TARGET test_api
    POST_BUILD
    COMMAND
        "${CMAKE_MAKE_PROGRAM}"
        /t:build
        /p:Configuration=Release
        /p:TEST_API_DLL=$<TARGET_FILE:test_api>
    WORKING_DIRECTORY "${CS_DIR}"
)
