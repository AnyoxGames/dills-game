13
1039382085640
908793927558548 1761162255469922900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 16.1809062957763672,
    "Y": -9.1947832107543945
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "908793928269639:1761162255470088600",
  "next_sibling": "908793926841437:1761162255469755800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "908793927782707:1761162255469975000",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "908793927795908:1761162255469978100",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "908793927782707:1761162255469975000",
    "DefaultRenderer": "908793927835124:1761162255469987200",
    "DepletedRenderer": "908793927844455:1761162255469989400"
  }
},
{
  "cid": 5,
  "aoid": "908793927804766:1761162255469980200",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
