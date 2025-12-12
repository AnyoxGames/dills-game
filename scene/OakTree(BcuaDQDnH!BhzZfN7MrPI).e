13
3040836845572
407809346779591 1761863975650374600
{
  "name": "OakTree",
  "local_enabled": true,
  "local_position": {
    "X": 11.3876762390136719,
    "Y": 8.6277418136596680
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "407801550013270:1761863973833719800",
  "next_sibling": "407818716499586:1761863977833528600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "OakTree.prefab"
},
{
  "cid": 3,
  "aoid": "407809347177169:1761863975650466100",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Oak Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 5,
  "aoid": "407809347320832:1761863975650499600",
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
},
{
  "cid": 1,
  "aoid": "407809347369465:1761863975650510900",
  "component_type": "Mono_Component",
  "mono_component_type": "OakTree",
  "data": {
    "Interactable": "407809347177169:1761863975650466100",
    "DefaultRenderer": "407809347423344:1761863975650523500",
    "DepletedRenderer": "407809347394534:1761863975650516800"
  }
}
